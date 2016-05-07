Imports System.Collections.ObjectModel
Imports System.Windows.Forms
Imports System.Drawing

Class MainWindow
    Public Property Files As ObservableCollection(Of FileEntry)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Files = New ObservableCollection(Of FileEntry)()
        DataContext = Me
    End Sub
    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub AddFile_Click(sender As Object, e As RoutedEventArgs)
        Dim browser As New OpenFileDialog
        browser.Filter = "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.tga|BMP|*.bmp|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|TGA|*.tga"

        If browser.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'MessageBox.Show(newgame.exepath)
            Dim x As ImageSource = New BitmapImage(New Uri(browser.FileName))
            Files.Add(New FileEntry() With {
        .Image = x,
        .FileName = browser.FileName})
        End If
    End Sub
    Private Sub _Delete_Click(sender As Object, e As RoutedEventArgs)
        'Games = New ObservableCollection(Of GameEntry)()

        Dim selection As FileEntry = _FileList.SelectedItem
        'MessageBox.Show(selection.GameName)
        If _FileList.SelectedItems.Count > 0 Then
            'If MessageBox.Show("Are you sure you want to delete " + selection.GameName + "?", "Really delete?", MessageBoxButton.YesNo) = vbYes Then
            Files.RemoveAt(_FileList.SelectedIndex)
            DataContext = Me
            'End If
        End If

    End Sub
    Private Sub AddFolder_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class

Public Class FileEntry
    Public Property Image As ImageSource
    Public Property FileName As String
End Class
