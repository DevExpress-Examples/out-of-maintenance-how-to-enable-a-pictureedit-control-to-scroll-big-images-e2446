<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128620835/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2446)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/ScrollPictureEdit/Form1.cs) (VB: [Form1.vb](./VB/ScrollPictureEdit/Form1.vb))
* [RepositoryItemScrollPictureEdit.cs](./CS/ScrollPictureEdit/RepositoryItemScrollPictureEdit.cs) (VB: [RepositoryItemScrollPictureEdit.vb](./VB/ScrollPictureEdit/RepositoryItemScrollPictureEdit.vb))
* [ScrollPictureEdit.cs](./CS/ScrollPictureEdit/ScrollPictureEdit.cs) (VB: [ScrollPictureEdit.vb](./VB/ScrollPictureEdit/ScrollPictureEdit.vb))
<!-- default file list end -->
# How to enable a PictureEdit control to scroll big images


<p>This example demonstrates how to enable a PictureEdit control to scroll images that don't fit into it. We have created a PictureEdit descendant and inserted scrollbars in it. Also we have added a Scrollable property indicating when scrollbars can be shown. It should be noted that scrollbars appear only when the SizeMode option is set to "Clip" because other values of SizeMode enable PictureEdit to fit the picture into its bounds in various ways. So when the Scrollable option is enabled SizeMode sets itself to the "Clip" value and on the contrary, when the ZoomMode option is set to a value other than "Clip" Scrollable disables itself.</p>

<br/>


