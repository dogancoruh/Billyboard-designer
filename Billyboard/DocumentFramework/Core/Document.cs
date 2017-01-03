using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DocumentFramework.Events;
using DocumentFramework.Enums;
using System.ComponentModel;

namespace DocumentFramework.Core
{
    public class Document : Component
    {
        public event EventHandler<DocumentNewEventArgs> OnNewDocument;
        public event EventHandler<DocumentNewPromptEventArgs> OnNewDocumentPrompt;
        public event EventHandler<DocumentOpenEventArgs> OnOpenDocument;
        public event EventHandler<ProjectOpenPromptEventArgs> OnOpenDocumentPrompt;
        public event EventHandler<DocumentSaveEventArgs> OnSaveDocument;
        public event EventHandler<DocumentSavePromptEventArgs> OnSaveDocumentPrompt;
        public event EventHandler<DocumentSaveAsEventArgs> OnSaveDocumentAs;
        public event EventHandler<DocumentSaveAsPromptEventArgs> OnSaveDoucmentAsPrompt;
        public event EventHandler<DocumentCloseEventArgs> OnCloseDocument;

        public event EventHandler<DocumentFileNameChangedEventArgs> OnDocumentFileNameChanged;
        public event EventHandler<DocumentModifiedEventArgs> OnDocumentModified;

        private string documentFileName;

        public string DocumentFileName
        {
            get { return documentFileName; }
            set
            {
                documentFileName = value;
                DoDocumentFileNameChange();
            }
        }
        

        private bool isDocumentModified;

        public bool IsDocumentModified
        {
            get { return isDocumentModified; }
            set
            {
                isDocumentModified = value; 
                DoDocumentModify();
            }
        }

        public string DefaultTitle { get; set; }

        [Browsable(false)]
        public string Title
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (documentFileName != string.Empty)
                    stringBuilder.Append(documentFileName);
                else
                    stringBuilder.Append("Unnamed");

                if (isDocumentModified)
                    stringBuilder.Append("*");

                stringBuilder.Append(" - ");

                stringBuilder.Append(DefaultTitle);

                return stringBuilder.ToString();
            }
        }

        public Document()
        {
            documentFileName = string.Empty;
            isDocumentModified = false;
        }

        virtual public bool NewDocument(string fileName = "")
        {
            if (isDocumentModified && !string.IsNullOrEmpty(documentFileName))
            {
                DocumentNewPromptEventArgs newPromptArgs = new DocumentNewPromptEventArgs();

                OnNewDocumentPrompt?.Invoke(this, newPromptArgs);

                switch (newPromptArgs.DialogResult)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.No:
                        break;
                    case DialogResult.Yes:
                        DocumentSaveEventArgs saveArgs = new DocumentSaveEventArgs();
                        saveArgs.FileName = documentFileName;
                        OnSaveDocument?.Invoke(this, saveArgs);

                        break;
                    default:
                        break;
                }
            }

            if (OnNewDocument != null)
            {
                DocumentNewEventArgs args = new DocumentNewEventArgs();
                args.FileName = fileName;
                args.Handled = false;
                OnNewDocument(this, args);

                if (args.Handled)
                {
                    DocumentFileName = args.FileName;
                    IsDocumentModified = true;
                    SaveDocument();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        virtual public bool OpenDocument(string fileName)
        {
            if (isDocumentModified && documentFileName != string.Empty)
            {
                if (OnOpenDocumentPrompt != null)
                {
                    ProjectOpenPromptEventArgs args = new ProjectOpenPromptEventArgs();

                    OnOpenDocumentPrompt(this, args);
                }
            }

            if (OnOpenDocument != null)
            {
                DocumentOpenEventArgs args = new DocumentOpenEventArgs();

                OnOpenDocument(this, args);

                DocumentFileName = fileName;
                IsDocumentModified = false;
                
                return true;
            }
            else
                return false;
        }

        virtual public bool OpenDocument()
        {
            if (isDocumentModified && documentFileName != string.Empty)
            {
                if (OnOpenDocumentPrompt != null)
                {
                    ProjectOpenPromptEventArgs args = new ProjectOpenPromptEventArgs();

                    OnOpenDocumentPrompt(this, args);

                    if (!args.IsHandled)
                        return false;
                }                
            }

            if (OnOpenDocument != null)
            {
                DocumentOpenEventArgs args = new DocumentOpenEventArgs();
                args.isHandled = false;

                OnOpenDocument(this, args);
                if (args.isHandled)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        virtual public void SaveDocument()
        {
            if ((isDocumentModified && documentFileName == string.Empty))
            {
                if (OnSaveDocumentPrompt != null)
                {
                    DocumentSavePromptEventArgs args = new DocumentSavePromptEventArgs();

                    OnSaveDocumentPrompt(this, args);

                    if (args.IsHandled)
                        DocumentFileName = args.FileName;
                    else
                        return;
                }
            }

            if (OnSaveDocument != null)
            {
                DocumentSaveEventArgs args = new DocumentSaveEventArgs();

                args.FileName = DocumentFileName;

                OnSaveDocument(this, args);
            }
        }

        virtual public void SaveDocumentAs()
        {
            string fileName_ = string.Empty;
            
            if (isDocumentModified && documentFileName != string.Empty)
            {
                if (OnSaveDoucmentAsPrompt != null)
                {
                    DocumentSaveAsPromptEventArgs args = new DocumentSaveAsPromptEventArgs();

                    OnSaveDoucmentAsPrompt(this, args);

                    if (args.IsHandled)
                        fileName_ = args.FileName;
                }
            }

            if (OnSaveDocumentAs != null)
            {
                DocumentSaveAsEventArgs args = new DocumentSaveAsEventArgs();
                args.FileName = fileName_;
                OnSaveDocumentAs(this, args);
            }
        }

        virtual public void CloseDocument()
        {
            if (OnCloseDocument != null)
            {
                DocumentCloseEventArgs args = new DocumentCloseEventArgs();
                args.FileName = string.Empty;

                OnCloseDocument(this, args);
            }
        }

        virtual public void DoDocumentFileNameChange()
        {
            if (OnDocumentFileNameChanged != null)
            {
                DocumentFileNameChangedEventArgs args = new DocumentFileNameChangedEventArgs();

                args.FileName = documentFileName;
                args.Title = Title;

                OnDocumentFileNameChanged(this, args);
            }
        }

        virtual public void DoDocumentModify()
        {
            if (OnDocumentModified != null)
            {
                DocumentModifiedEventArgs args = new DocumentModifiedEventArgs();

                args.FileName = documentFileName;
                args.IsModified = isDocumentModified;
                args.Title = Title;

                OnDocumentModified(this, args);
            }
        }

        public void RefreshTitle()
        {
            DoDocumentFileNameChange();
        }
    }
}
