Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace nsScrollPictureEdit
	Friend Class ScrollPictureEdit
		Inherits PictureEdit
		Private vScroll As DevExpress.XtraEditors.VScrollBar = Nothing
		Private hScroll As DevExpress.XtraEditors.HScrollBar = Nothing

		Shared Sub New()
			RepositoryItemScrollPictureEdit.Register()
		End Sub

		Public Sub New()
			MyBase.New()
			CreateVerticalScrollBar()
			CreateHorizontalScrollBar()

			hScroll.Show()
			vScroll.Show()
		End Sub

		Private Sub CreateVerticalScrollBar()
			If vScroll IsNot Nothing Then
				Return
			End If

			vScroll = New DevExpress.XtraEditors.VScrollBar()
			vScroll.Parent = Me
			vScroll.ScrollBarAutoSize = True

			AddHandler vScroll.Scroll, AddressOf OnVerticalScroll
			AddHandler vScroll.HandleCreated, AddressOf OnScrollBarHandleCreated
		End Sub

		Private Sub CreateHorizontalScrollBar()
			If hScroll IsNot Nothing Then
				Return
			End If

			hScroll = New DevExpress.XtraEditors.HScrollBar()
			hScroll.Parent = Me
			hScroll.ScrollBarAutoSize = True

			AddHandler hScroll.Scroll, AddressOf OnHorizontalScroll
			AddHandler hScroll.HandleCreated, AddressOf OnScrollBarHandleCreated
		End Sub

		Protected Overridable Sub OnScrollBarHandleCreated(ByVal sender As Object, ByVal e As EventArgs)
			CType(sender, DevExpress.XtraEditors.ScrollBarBase).Value = 0
		End Sub

		Protected Overridable Sub OnVerticalScroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
			Me.Refresh()
		End Sub

		Protected Overridable Sub OnHorizontalScroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
			Me.Refresh()
		End Sub

		Protected Overridable Function CalcVScrollBarMaximum() As Integer
			If Me.Image.Width > Me.Width Then
				Return Me.Image.Height - Me.Height + vScroll.LargeChange - 1 + hScroll.Height
			End If

			Return Me.Image.Height - Me.Height + vScroll.LargeChange - 1
		End Function

		Protected Overridable Function CalcHScrollBarMaximum() As Integer
			If Me.Image.Height > Me.Height Then
				Return Me.Image.Width - Me.Width + hScroll.LargeChange - 1 + vScroll.Width
			End If

			Return Me.Image.Width - Me.Width + hScroll.LargeChange - 1
		End Function

		Protected Overridable Sub UpdateScrollBars()
			If Me.Image IsNot Nothing AndAlso Me.Properties.Scrollable Then
				If Me.Image.Height > Me.Height Then
					vScroll.Left = Me.Width - vScroll.Width
					If Me.Image.Width > Me.Width Then
						vScroll.Height = Me.Height - hScroll.Height
					Else
						vScroll.Height = Me.Height
					End If
					vScroll.Maximum = CalcVScrollBarMaximum()
					vScroll.Show()
				Else
					vScroll.Hide()
				End If

				If Me.Image.Width > Me.Width Then
					hScroll.Top = Me.Height - hScroll.Height
					If Me.Image.Height > Me.Height Then
						hScroll.Width = Me.Width - vScroll.Width
					Else
						hScroll.Width = Me.Width
					End If
					hScroll.Maximum = CalcHScrollBarMaximum()
					hScroll.Show()
				Else
					hScroll.Hide()
				End If
			Else
				vScroll.Hide()
				hScroll.Hide()
			End If
		End Sub

		Protected Overrides Sub LayoutChanged()
			MyBase.LayoutChanged()
			UpdateScrollBars()
		End Sub

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			If Me.Image IsNot Nothing AndAlso Me.Properties.Scrollable Then
				e.Graphics.DrawImage(Me.Image, e.ClipRectangle, hScroll.Value, vScroll.Value, e.ClipRectangle.Width, e.ClipRectangle.Height, GraphicsUnit.Pixel)

				If vScroll.Visible AndAlso hScroll.Visible Then
					Dim blackRect As New Rectangle(hScroll.Width, hScroll.Top, vScroll.Left + vScroll.Width, hScroll.Top + hScroll.Height)
					e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), blackRect)
				End If
			Else
				MyBase.OnPaint(e)
			End If
		End Sub

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemScrollPictureEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemScrollPictureEdit)
			End Get
		End Property

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemScrollPictureEdit.EditorName
			End Get
		End Property
	End Class
End Namespace