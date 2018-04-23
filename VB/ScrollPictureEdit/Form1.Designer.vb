Namespace nsScrollPictureEdit
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Form1
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Me.ScrollPictureEdit1 = New nsScrollPictureEdit.ScrollPictureEdit
            Me.GridControl1 = New DevExpress.XtraGrid.GridControl
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
            Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
            CType(Me.ScrollPictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ScrollPictureEdit1
            '
            Me.ScrollPictureEdit1.EditValue = CType(resources.GetObject("ScrollPictureEdit1.EditValue"), Object)
            Me.ScrollPictureEdit1.Location = New System.Drawing.Point(12, 12)
            Me.ScrollPictureEdit1.Name = "ScrollPictureEdit1"
            Me.ScrollPictureEdit1.Properties.Scrollable = True
            Me.ScrollPictureEdit1.Size = New System.Drawing.Size(234, 160)
            Me.ScrollPictureEdit1.TabIndex = 0
            '
            'GridControl1
            '
            Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.GridControl1.Location = New System.Drawing.Point(0, 178)
            Me.GridControl1.MainView = Me.GridView1
            Me.GridControl1.Name = "GridControl1"
            Me.GridControl1.Size = New System.Drawing.Size(482, 388)
            Me.GridControl1.TabIndex = 1
            Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
            '
            'GridView1
            '
            Me.GridView1.GridControl = Me.GridControl1
            Me.GridView1.Name = "GridView1"
            '
            'GridView2
            '
            Me.GridView2.GridControl = Me.GridControl1
            Me.GridView2.Name = "GridView2"
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(482, 566)
            Me.Controls.Add(Me.GridControl1)
            Me.Controls.Add(Me.ScrollPictureEdit1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.ScrollPictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ScrollPictureEdit1 As nsScrollPictureEdit.ScrollPictureEdit
        Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    End Class
End Namespace

