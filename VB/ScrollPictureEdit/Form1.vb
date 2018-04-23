Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Namespace nsScrollPictureEdit
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            GridControl1.DataSource = CreateTable(3)
            GridView1.RowHeight = 100

            GridView1.Columns("Image").ColumnEdit = New RepositoryItemScrollPictureEdit()
            CType(GridView1.Columns("Image").ColumnEdit, RepositoryItemScrollPictureEdit).Scrollable = True
            CType(GridView1.Columns("Image").ColumnEdit, RepositoryItemScrollPictureEdit).PictureAlignment = ContentAlignment.TopLeft
        End Sub

        Private Function CreateTable(ByVal RowCount As Integer) As DataTable
            Dim tbl As New DataTable()
            tbl.Columns.Add("Name", GetType(String))
            tbl.Columns.Add("Image", GetType(Image))

            For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() {String.Format("Name{0}", i), Resources.Image})
            Next i

            Return tbl
        End Function
    End Class
End Namespace