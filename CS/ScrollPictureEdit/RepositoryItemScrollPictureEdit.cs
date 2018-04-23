using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace nsScrollPictureEdit
{
    class RepositoryItemScrollPictureEdit : RepositoryItemPictureEdit
    {
        internal const string EditorName = "ZoomPictureEdit";
        private bool scrollable;

        static RepositoryItemScrollPictureEdit()
        {
            Register();
        }
        public RepositoryItemScrollPictureEdit()
        {
        }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(ScrollPictureEdit),
                typeof(RepositoryItemScrollPictureEdit), typeof(PictureEditViewInfo),
                    new PictureEditPainter(), true, null));
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                this.Scrollable = ((RepositoryItemScrollPictureEdit)item).Scrollable;
            }
            finally
            {
                EndUpdate();  
            }
           
        }

        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        public bool Scrollable
        {
            get { return scrollable; }
            set
            {
                scrollable = value;
                if ( scrollable )
                    this.SizeMode = PictureSizeMode.Clip;

                this.OnPropertiesChanged();
            }
        }

        public new PictureSizeMode SizeMode
        {
            get { return base.SizeMode; }
            set
            {
                base.SizeMode = value;
                if ( SizeMode != PictureSizeMode.Clip )
                    Scrollable = false;
            }
        }
    }
}
