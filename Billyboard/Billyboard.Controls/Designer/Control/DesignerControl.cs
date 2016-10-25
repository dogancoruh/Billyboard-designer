﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Billyboard.Controls.Designer.Data;
using Billyboard.Controls.Designer.Renderer;
using Billyboard.Controls.Utilities;
using Billyboard.Controls.Designer.Utilities;
using System.Drawing.Drawing2D;
using Billyboard.Controls.Designer.Core;

namespace Billyboard.Controls.Designer.Control
{
    public enum InteractionState
    {
        None,
        Selection,
        Pan,
        Move,
        SizeAttempt,
        Size
    }

    public enum PanSource
    {
        None,
        Mouse,
        Keyboard
    }

    public partial class DesignerControl : UserControl
    {
        const double MOVE_THRESHOLD = 2;
        const double SIZE_THRESHOLD = 2;
        const double SELECTION_THRESHOLD = 2;

        private Layout layout;

        // selection
        private List<LayoutElement> selectedElements;
        private List<Point> selectedElementOffsets;

        private Dictionary<string, LayoutElementRenderer> elementRenderers;

        private double ZoomRatio
        {
            get { return layout != null ? layout.ZoomRatio : 1.0; }
        }

        // workspace
        public Size WorkspaceSize
        {
            get { return layout != null ? layout.WorkspaceSize : Size.Empty; }
        }

        public void AddElementRenderer(string typeName, Type type)
        {
            if (!elementRenderers.ContainsKey(typeName))
            {
                LayoutElementRenderer elementRenderer = (LayoutElementRenderer)Activator.CreateInstance(type);
                elementRenderers.Add(typeName, elementRenderer);
            }
            else
                throw new Exception(string.Format("Element render already registered for type [{0}]", typeName));
        }

        // design area
        public Point DesignAreaLocation
        {
            get
            {
                return new Point(WorkspaceSize.Width / 2 - DesignAreaSize.Width / 2,
                                 WorkspaceSize.Height / 2 - DesignAreaSize.Height / 2).Multiply(ZoomRatio);
            }
        }
        public Size DesignAreaSize
        {
            get
            {
                return Layout != null ? Layout.DesignAreaSize : Size.Empty;
            }
        }
        public Rectangle DesignAreaRectangle
        {
            get { return new Rectangle(DesignAreaLocation, DesignAreaSize); }
        }

        // viewport
        private Point oldViewportLocation;
        public Point ViewportLocation { get; set; }
        public Size ViewportSize
        {
            get { return new Size(Width - vScrollBar.Width, Height - hScrollBar.Height); }
        }
        public Rectangle ViewportRectangle
        {
            get { return new Rectangle(ViewportLocation, ViewportSize); }
        }

        // mouse properties
        private bool isMouseDown;
        private bool mouseHitsSelection;
        private Point controlMouseDownLocation;
        private Point controlMouseMoveLocation;
        private PanSource panSource = PanSource.None;
        private TransformHandle transformHandle;

        public new Layout Layout
        {
            get { return layout; }
            set
            {
                layout = value;

                LayoutScrollBars();
                UpdateScrollBars();

                Refresh();
            }
        }

        private InteractionState interactionState;

        private Rectangle SelectionRectangle
        {
            get
            {
                return DesignerHelper.GetRectangleFromTwoPoints(controlMouseDownLocation, controlMouseMoveLocation);
            }
        }

        public DesignerControl()
        {
            InitializeComponent();
            InitializeElementRenderers();

            BackColor = ColorTranslator.FromHtml("#ebecef");

            DoubleBuffered = true;

            ViewportLocation = Point.Empty;

            hScrollBar.ValueChanged += HScrollBar_ValueChanged;
            vScrollBar.ValueChanged += VScrollBar_ValueChanged;
        }

        private void HScrollBar_ValueChanged(object sender, EventArgs e)
        {
            ViewportLocation = new Point(hScrollBar.Value,
                                         ViewportLocation.Y);

            Refresh();
        }

        private void VScrollBar_ValueChanged(object sender, EventArgs e)
        {
            ViewportLocation = new Point(ViewportLocation.X,
                                         vScrollBar.Value);

            Refresh();
        }

        private void InitializeElementRenderers()
        {
            elementRenderers = new Dictionary<string, LayoutElementRenderer>();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            controlMouseDownLocation = e.Location;

            isMouseDown = true;

            bool needsRefresh = false;

            mouseHitsSelection = false;

            if (e.Button == MouseButtons.Left)
            {
                // resize
                if (interactionState == InteractionState.None && selectedElements != null && selectedElements.Count == 1)
                {
                    LayoutProperties layoutProperties = new LayoutProperties();
                    layoutProperties.DesignAreaLocation = DesignAreaLocation;
                    layoutProperties.DesignAreaSize = DesignAreaSize;
                    layoutProperties.ViewportLocation = ViewportLocation;
                    layoutProperties.ViewportSize = ViewportSize;
                    layoutProperties.ZoomRatio = ZoomRatio;

                    foreach (LayoutElement selectedElement in selectedElements)
                    {
                        TransformHandle transformHandle = DesignerHelper.GetTransformHandleType(selectedElement, layoutProperties, e.Location);
                        if (transformHandle != TransformHandle.None)
                        {
                            this.transformHandle = transformHandle;
                            interactionState = InteractionState.SizeAttempt;
                            needsRefresh = true;
                        }
                    }
                }

                // click selection
                if (interactionState == InteractionState.None)
                {
                    LayoutElement element = GetElementByLocation(controlMouseDownLocation);
                    if (element != null)
                    {
                        mouseHitsSelection = true;

                        if (KeyboardHelper.IsShiftKeyPressed)
                        {
                            if (!IsElementInSelection(element))
                                AddElementToSelection(element);
                            else
                                RemoveElementFromSelection(element);
                        }
                        else
                        {
                            if (!IsElementInSelection(element))
                            {
                                ClearSelection();
                                AddElementToSelection(element);
                            }
                        }

                        needsRefresh = true;
                    }
                    else
                    {
                        if (!KeyboardHelper.IsShiftKeyPressed)
                        {
                            ClearSelection();
                            needsRefresh = true;
                        }
                    }
                }
            }

            if (e.Button == MouseButtons.Middle || interactionState == InteractionState.Pan)
            {
                interactionState = InteractionState.Pan;

                if (panSource == PanSource.None)
                    panSource = PanSource.Mouse;

                oldViewportLocation = ViewportLocation;

                Cursor = CursorHelper.LoadFromResource(Properties.Resources.grabbing);

                needsRefresh = true;
            }

            if (needsRefresh)
                Refresh();
        }

        private Point GetWorkspaceLocationFromControlLocation(Point controlLocation)
        {
            return new Point(ViewportLocation.X + controlLocation.X, ViewportLocation.Y + controlLocation.Y);
        }

        private Point GetDesignAreaLocationFromControlLocation(Point controlLocation)
        {
            return new Point(ViewportLocation.X + controlLocation.X - DesignAreaLocation.X,
                             ViewportLocation.Y + controlLocation.Y - DesignAreaLocation.Y);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            controlMouseMoveLocation = e.Location;
            
            bool needsRefresh = false;

            LayoutProperties layoutProperties = new LayoutProperties();
            layoutProperties.DesignAreaLocation = DesignAreaLocation;
            layoutProperties.DesignAreaSize = DesignAreaSize;
            layoutProperties.ViewportLocation = ViewportLocation;
            layoutProperties.ViewportSize = ViewportSize;
            layoutProperties.ZoomRatio = ZoomRatio;

            if (selectedElements != null)
            {
                foreach (LayoutElement selectedElement in selectedElements)
                {
                    TransformHandle handle = DesignerHelper.GetTransformHandleType(selectedElement, layoutProperties, controlMouseMoveLocation);
                    Cursor = DesignerHelper.GetCursorForTransformHandle(handle);
                }
            }

            if (isMouseDown)
            {
                // move
                if (interactionState == InteractionState.None && mouseHitsSelection && DesignerHelper.ExceedsThreshold(controlMouseMoveLocation, controlMouseDownLocation, MOVE_THRESHOLD))
                {
                    interactionState = InteractionState.Move;

                    // store offsets by mouse location
                    selectedElementOffsets = new List<Point>();
                    foreach (LayoutElement selectedElement in selectedElements)
                    {
                        Point selectedElementLocation = selectedElement.Location.Multiply(ZoomRatio);
                        selectedElementLocation = selectedElementLocation.Add(DesignAreaLocation);
                        selectedElementLocation = selectedElementLocation.Subtract(ViewportLocation);

                        Console.WriteLine(string.Format("x > {0}", controlMouseMoveLocation.X - selectedElementLocation.X));
                        Console.WriteLine(string.Format("y > {0}", controlMouseMoveLocation.Y - selectedElementLocation.Y));

                        selectedElementOffsets.Add(new Point(controlMouseMoveLocation.X - selectedElementLocation.X,
                                                             controlMouseMoveLocation.Y - selectedElementLocation.Y));
                    }
                }

                if (interactionState == InteractionState.SizeAttempt && DesignerHelper.ExceedsThreshold(controlMouseMoveLocation, controlMouseDownLocation, SIZE_THRESHOLD))
                {
                    interactionState = InteractionState.Size;

                    DesignerHelper.SizeElement(selectedElements[0], transformHandle, controlMouseDownLocation, controlMouseMoveLocation);
                }

                if (interactionState == InteractionState.Move)
                {
                    for (int i = 0; i < selectedElements.Count; i++)
                    {
                        LayoutElement selectedElement = selectedElements[i];
                        Point selectedElementOffset = selectedElementOffsets[i];

                        int selectedElementX = controlMouseMoveLocation.X + ViewportLocation.X - DesignAreaLocation.X;
                        selectedElementX -= selectedElementOffset.X;

                        int selectedElementY = controlMouseMoveLocation.Y + ViewportLocation.Y - DesignAreaLocation.Y;
                        selectedElementY -= selectedElementOffset.Y;

                        selectedElement.Location = new Point(selectedElementX, selectedElementY).Divide(ZoomRatio);
                    }

                    needsRefresh = true;
                }

                // selection
                if (interactionState == InteractionState.None && !mouseHitsSelection && DesignerHelper.ExceedsThreshold(controlMouseMoveLocation, controlMouseDownLocation, SELECTION_THRESHOLD))
                {
                    interactionState = InteractionState.Selection;
                    needsRefresh = true;
                }

                if (interactionState == InteractionState.Selection)
                    needsRefresh = true;

                if (interactionState == InteractionState.Pan)
                {
                    ViewportLocation = oldViewportLocation.Subtract(controlMouseMoveLocation.Subtract(controlMouseDownLocation));
                    ValidateViewportLocation();

                    UpdateScrollBars();
                    needsRefresh = true;
                }
            }

            if (needsRefresh)
                Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            isMouseDown = false;

            if (interactionState == InteractionState.Selection)
            {
                selectedElements = GetElementsByRectangle(SelectionRectangle);
                interactionState = InteractionState.None;
                Cursor = Cursors.Default;
            }
            else if (interactionState == InteractionState.Pan)
            {
                if (panSource == PanSource.Mouse)
                {
                    interactionState = InteractionState.None;
                    panSource = PanSource.None;
                    Cursor = Cursors.Default;
                }
                else if (panSource == PanSource.Keyboard)
                    Cursor = CursorHelper.LoadFromResource(Properties.Resources.grab);
            }
            else
            {
                interactionState = InteractionState.None;
                Cursor = Cursors.Default;
            }

            Refresh();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            Point mouseLocation = e.Location;

            Console.WriteLine(e.Delta.ToString());

            if (layout != null)
            {
                double zoomDelta = e.Delta * 0.001;

                Point workspaceMouseLocation = GetWorkspaceLocationFromControlLocation(mouseLocation);
                workspaceMouseLocation = workspaceMouseLocation.Divide(ZoomRatio);
                Point deltaWorkspaceMouseLocation = workspaceMouseLocation.Multiply(zoomDelta);

                if (layout.IncreaseZoomRatio(zoomDelta))
                {
                    // apply new location
                    ViewportLocation = ViewportLocation.Add(deltaWorkspaceMouseLocation);

                    // boundry check for scrollbar crash
                    ValidateViewportLocation();

                    UpdateScrollBars();

                    Refresh();
                }
            }
        }

        private void ValidateViewportLocation()
        {
            if (ViewportLocation.X < 0)
                ViewportLocation = new Point(0, ViewportLocation.Y);

            if (ViewportLocation.Y < 0)
                ViewportLocation = new Point(ViewportLocation.X, 0);

            if (ViewportLocation.X > (int)(WorkspaceSize.Width * ZoomRatio) - ViewportSize.Width)
                ViewportLocation = new Point((int)(WorkspaceSize.Width * ZoomRatio) - ViewportSize.Width, ViewportLocation.Y);

            if (ViewportLocation.Y > (int)(WorkspaceSize.Height * ZoomRatio) - ViewportSize.Height)
                ViewportLocation = new Point(ViewportLocation.X, (int)(WorkspaceSize.Height * ZoomRatio) - ViewportSize.Height);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyData == Keys.Space)
            {
                if (interactionState == InteractionState.None)
                {
                    interactionState = InteractionState.Pan;
                    panSource = PanSource.Keyboard;
                    Cursor = CursorHelper.LoadFromResource(Properties.Resources.grab);
                    Refresh();
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyData == Keys.Space)
            {
                if (interactionState == InteractionState.Pan)
                {
                    interactionState = InteractionState.None;
                    panSource = PanSource.None;
                    Cursor = Cursors.Default;
                    Refresh();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Layout != null)
            {
                DrawDesignArea(e.Graphics);

                DrawElements(e.Graphics);

                if (interactionState == InteractionState.Selection)
                    DrawSelection(e.Graphics, SelectionRectangle);

                DrawInteractionState(e.Graphics, interactionState);
            }
        }

        private void DrawDesignArea(Graphics graphics)
        {
            Brush brush = new SolidBrush(Layout.DesignAreaBackgroundColor);
            graphics.FillRectangle(brush, new Rectangle(DesignAreaLocation.Subtract(ViewportLocation), DesignAreaSize.Multiply(ZoomRatio)));
        }

        private void DrawElements(Graphics graphics)
        {
            LayoutProperties layoutProperties = new LayoutProperties();
            layoutProperties.DesignAreaLocation = DesignAreaLocation;
            layoutProperties.DesignAreaSize = DesignAreaSize;
            layoutProperties.ViewportLocation = ViewportLocation;
            layoutProperties.ViewportSize = ViewportSize;
            layoutProperties.ZoomRatio = ZoomRatio;
            
            foreach (LayoutElement element in Layout.Elements)
            {
                LayoutElementRenderer elementRenderer = GetElementRendererForElementType(element.TypeName);
                if (elementRenderer != null)
                {
                    elementRenderer.Draw(element, graphics, layoutProperties);

                    if (IsElementInSelection(element))
                    {
                        TransformHandleType transformHandleType = TransformHandleType.All;
                        VisualLayoutElement visualLayoutElement = element as VisualLayoutElement;
                        if (visualLayoutElement != null && !visualLayoutElement.Rotatable)
                        {
                            if (!KeyboardHelper.IsShiftKeyPressed)
                                transformHandleType = TransformHandleType.All;
                            else
                                transformHandleType = TransformHandleType.OnlyCorners;
                        }

                        DesignerHelper.DrawTransformHandles(graphics, element, layoutProperties, transformHandleType);
                    }
                }
                else
                    throw new Exception("Element renderer for element type not found!");
            }
        }

        private void DrawSelection(Graphics graphics, Rectangle rectangle)
        {
            Pen pen = new Pen(Color.FromArgb(100, Color.Black));
            Brush brush = new SolidBrush(Color.FromArgb(100, Color.Gray));
            graphics.FillRoundedRectangle(brush, rectangle, 1);
            graphics.DrawRoundedRectangle(pen, rectangle, 1);
        }

        private void DrawInteractionState(Graphics graphics, InteractionState interactionState)
        {
            Font font = new Font("Arial", 10);
            Brush brush = new SolidBrush(Color.Black);

            graphics.DrawString(string.Format("InteractionState : {0}", interactionState), font, brush, new Point(10, Height - 40));
            graphics.DrawString(string.Format("Ratio : {0:0.00}", ZoomRatio), font, brush, new Point(10, Height - 60));
            graphics.DrawString(string.Format("MouseLocation : {0}", GetWorkspaceLocationFromControlLocation(controlMouseMoveLocation)), font, brush, new Point(10, Height - 80));
        }

        private LayoutElementRenderer GetElementRendererForElementType(string typeName)
        {
            if (elementRenderers.ContainsKey(typeName))
                return elementRenderers[typeName];

            return null;
        }

        private LayoutElement GetElementByLocation(Point location)
        {
            foreach (LayoutElement element in layout.Elements)
            {
                Point elementLocation = element.Location.Multiply(ZoomRatio);
                elementLocation = elementLocation.Add(DesignAreaLocation);
                elementLocation = elementLocation.Subtract(ViewportLocation);

                Size elementSize = element.Size;
                elementSize = elementSize.Multiply(ZoomRatio);

                Rectangle elementRect = new Rectangle(elementLocation, elementSize);
                if (elementRect.Contains(location))
                    return element;
            }

            return null;
        }

        private bool IsElementInSelection(LayoutElement element)
        {
            return selectedElements != null ? selectedElements.Contains(element) : false;
        }

        private void AddElementToSelection(LayoutElement element)
        {
            if (selectedElements == null)
                selectedElements = new List<LayoutElement>();

            selectedElements.Add(element);
        }

        private void RemoveElementFromSelection(LayoutElement element)
        {
            if (selectedElements != null)
                selectedElements.Remove(element);
        }

        private void ClearSelection()
        {
            if (selectedElements != null)
                selectedElements = null;
        }

        private List<LayoutElement> GetElementsByRectangle(Rectangle selectionRectangle)
        {
            List<LayoutElement> result = new List<LayoutElement>();

            foreach (LayoutElement element in layout.Elements)
            {
                Point elementLocation = element.Location.Multiply(ZoomRatio);
                elementLocation = elementLocation.Add(DesignAreaLocation);
                elementLocation = elementLocation.Subtract(ViewportLocation);

                Size elementSize = element.Size.Multiply(ZoomRatio);

                Rectangle elementRectangle = new Rectangle(elementLocation, elementSize);

                if (elementRectangle.IntersectsWith(selectionRectangle))
                    result.Add(element);
            }

            return result;
        }

        public void LayoutScrollBars()
        {
            if (Layout != null)
            {
                hScrollBar.Left = 0;
                hScrollBar.Top = Height - hScrollBar.Height;
                hScrollBar.Width = Width - vScrollBar.Width;

                vScrollBar.Left = Width - vScrollBar.Width;
                vScrollBar.Top = 0;
                vScrollBar.Height = Height - hScrollBar.Height;
            }
        }

        public void UpdateScrollBars()
        {
            if (Layout != null)
            {
                hScrollBar.Maximum = (int)(WorkspaceSize.Width * ZoomRatio);
                vScrollBar.Maximum = (int)(WorkspaceSize.Height * ZoomRatio);

                hScrollBar.Value = ViewportLocation.X;
                vScrollBar.Value = ViewportLocation.Y; 
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            LayoutScrollBars();
            UpdateScrollBars();
        }

        public void LocateViewport(Point location)
        {
            ViewportLocation = new Point((int)(location.X * ZoomRatio) / 2 - ViewportSize.Width / 2,
                                         (int)(location.Y * ZoomRatio) / 2 - ViewportSize.Height / 2);

            // boundry check for scrollbar crash
            ValidateViewportLocation();

            UpdateScrollBars();
            Refresh();
        }

        public void CenterViewport()
        {
            ViewportLocation = new Point((int)(WorkspaceSize.Width * ZoomRatio) / 2 - ViewportSize.Width / 2,
                                         (int)(WorkspaceSize.Height * ZoomRatio) / 2 - ViewportSize.Height / 2);
            UpdateScrollBars();
            Refresh();
        }

        private void buttonViewportCenter_Click(object sender, EventArgs e)
        {
            CenterViewport();
        }
    }
}
