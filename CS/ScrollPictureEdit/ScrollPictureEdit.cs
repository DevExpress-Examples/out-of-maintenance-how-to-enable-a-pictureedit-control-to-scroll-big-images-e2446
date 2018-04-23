using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace nsScrollPictureEdit
{
    class ScrollPictureEdit : PictureEdit
    {
        private DevExpress.XtraEditors.VScrollBar vScroll = null;
        private DevExpress.XtraEditors.HScrollBar hScroll = null;

        static ScrollPictureEdit()
        {
            RepositoryItemScrollPictureEdit.Register();
        }

        public ScrollPictureEdit()
            : base()
        {
            CreateVerticalScrollBar();
            CreateHorizontalScrollBar();

            hScroll.Show();
            vScroll.Show();
        }

        private void CreateVerticalScrollBar()
        {
            if ( vScroll != null )
                return;

            vScroll = new DevExpress.XtraEditors.VScrollBar();
            vScroll.Parent = this;
            vScroll.ScrollBarAutoSize = true;

            vScroll.Scroll += new ScrollEventHandler(OnVerticalScroll);
            vScroll.HandleCreated += new EventHandler(OnScrollBarHandleCreated);
        }

        private void CreateHorizontalScrollBar()
        {
            if ( hScroll != null )
                return;

            hScroll = new DevExpress.XtraEditors.HScrollBar();
            hScroll.Parent = this;
            hScroll.ScrollBarAutoSize = true;

            hScroll.Scroll += new ScrollEventHandler(OnHorizontalScroll);
            hScroll.HandleCreated += new EventHandler(OnScrollBarHandleCreated);
        }

        protected virtual void OnScrollBarHandleCreated(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.ScrollBarBase)sender).Value = 0;
        }

        protected virtual void OnVerticalScroll(Object sender, ScrollEventArgs e)
        {
            this.Refresh();
        }

        protected virtual void OnHorizontalScroll(Object sender, ScrollEventArgs e)
        {
            this.Refresh();
        }

        protected virtual int CalcVScrollBarMaximum()
        {
            if ( this.Image.Width > this.Width )
                return this.Image.Height - this.Height + vScroll.LargeChange - 1 + hScroll.Height;

            return this.Image.Height - this.Height + vScroll.LargeChange - 1;
        }

        protected virtual int CalcHScrollBarMaximum()
        {
            if ( this.Image.Height > this.Height )
                return this.Image.Width - this.Width + hScroll.LargeChange - 1 + vScroll.Width;

            return this.Image.Width - this.Width + hScroll.LargeChange - 1;
        }

        protected virtual void UpdateScrollBars()
        {
            if ( this.Image != null && this.Properties.Scrollable )
            {
                if ( this.Image.Height > this.Height )
                {
                    vScroll.Left = this.Width - vScroll.Width;
                    vScroll.Height = this.Image.Width > this.Width ? this.Height - hScroll.Height : this.Height;
                    vScroll.Maximum = CalcVScrollBarMaximum();
                    vScroll.Show();
                }
                else
                    vScroll.Hide();

                if ( this.Image.Width > this.Width )
                {
                    hScroll.Top = this.Height - hScroll.Height;
                    hScroll.Width = this.Image.Height > this.Height ? this.Width - vScroll.Width : this.Width;
                    hScroll.Maximum = CalcHScrollBarMaximum();
                    hScroll.Show();
                }
                else
                    hScroll.Hide();
            }
            else
            {
                vScroll.Hide();
                hScroll.Hide();
            }
        }

        protected override void LayoutChanged()
        {
            base.LayoutChanged();
            UpdateScrollBars();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if ( this.Image != null && this.Properties.Scrollable )
            {
                e.Graphics.DrawImage(this.Image, e.ClipRectangle, hScroll.Value, vScroll.Value, e.ClipRectangle.Width, e.ClipRectangle.Height, GraphicsUnit.Pixel);

                if ( vScroll.Visible && hScroll.Visible )
                {
                    Rectangle blackRect = new Rectangle(hScroll.Width, hScroll.Top, vScroll.Left + vScroll.Width, hScroll.Top + hScroll.Height);
                    e.Graphics.FillRectangle(new SolidBrush(this.BackColor), blackRect);
                }
            }
            else
                base.OnPaint(e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemScrollPictureEdit Properties
        {
            get { return base.Properties as RepositoryItemScrollPictureEdit; }
        }

        public override string EditorTypeName
        {
            get { return RepositoryItemScrollPictureEdit.EditorName; }
        }
    }
}