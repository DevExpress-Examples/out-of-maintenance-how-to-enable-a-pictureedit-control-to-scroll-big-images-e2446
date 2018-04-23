Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo

Namespace nsScrollPictureEdit
	Friend Class RepositoryItemScrollPictureEdit
		Inherits RepositoryItemPictureEdit
		Friend Const EditorName As String = "ZoomPictureEdit"
		Private scrollable_Renamed As Boolean

		Shared Sub New()
			Register()
		End Sub
		Public Sub New()
		End Sub

		Public Shared Sub Register()
            EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(EditorName, GetType(ScrollPictureEdit), GetType(RepositoryItemScrollPictureEdit), GetType(PictureEditViewInfo), New PictureEditPainter(), True))
		End Sub

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			Try
				MyBase.Assign(item)
				Me.Scrollable = (CType(item, RepositoryItemScrollPictureEdit)).Scrollable
			Finally
				EndUpdate()
			End Try

		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return EditorName
			End Get
		End Property

		Public Property Scrollable() As Boolean
			Get
				Return scrollable_Renamed
			End Get
			Set(ByVal value As Boolean)
				scrollable_Renamed = value
				If scrollable_Renamed Then
					Me.SizeMode = PictureSizeMode.Clip
				End If

				Me.OnPropertiesChanged()
			End Set
		End Property

		Public Shadows Property SizeMode() As PictureSizeMode
			Get
				Return MyBase.SizeMode
			End Get
			Set(ByVal value As PictureSizeMode)
				MyBase.SizeMode = value
				If SizeMode <> PictureSizeMode.Clip Then
					Scrollable = False
				End If
			End Set
		End Property
	End Class
End Namespace
