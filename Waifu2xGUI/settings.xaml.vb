Imports System.Windows.Forms
Public Class settings
    'waifu2x-converter_x64  [--block_size <0|128|512|1024>] [--disable-gpu]
    '                      [-j <integer>] [--model_dir <string>]
    '                      [--scale_ratio <double>] [--noise_level <1|2>]
    '                      [-m <noise|scale|noise_scale>] [-o <string>] -i
    '                       <String>

    Public Property block_size As String = "" '
    Public Property disable_gpu As String = "" '
    Public Property j As String = "" ' 
    Public Property model_dir As String = "" '
    Public Property scale_ratio As String = "" '
    Public Property noise_level As String = "" '
    Public Property mode As String = "" '
    Public Property outfolder As String = ""
    Public Property extention As String = ""

    Public Property commandflags As String = ""


    Private Sub StartButton_Click(sender As Object, e As RoutedEventArgs)
        If Not (cbBlockSize.Text = "Not Set") Then
            block_size = "--block_size " + cbBlockSize.Text + " "
        End If
        If Not (cbNoiseLevel.Text = "Not Set") Then
            noise_level = "--noise_level " + cbNoiseLevel.Text + " "
        End If
        Select Case cbMode.Text
            Case "Not Set"
                mode = ""
            Case "Noise Scale"
                mode = "-m noise_scale "
            Case "Noise"
                mode = "-m noise "
            Case "Scale"
                mode = "-m scale "
        End Select
        If cbDisGPU.IsChecked Then
            disable_gpu = "--disable-gpu "
        End If
        If Not (tbThread.Text = "") Then
            j = "-j " + tbThread.Text + " "
        End If
        If Not (tbModelDir.Text = "") Then
            model_dir = "--model_dir " + tbModelDir.Text + " "
        End If
        If Not (tbScaleRatio.Text = "") Then
            scale_ratio = "--scale_ratio " + tbScaleRatio.Text + " "
        End If
        If Not (tbOutDir.Text = "") Then
            outfolder = "-o """ + tbOutDir.Text
        End If
        extention = cbFileType.Text
        commandflags = block_size + disable_gpu + j + model_dir + scale_ratio + noise_level + mode
        DialogResult = True
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub BrowseBtn_Click(sender As Object, e As RoutedEventArgs)
        Dim folder As New FolderBrowserDialog
        If folder.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            tbOutDir.Text = folder.SelectedPath
        End If
    End Sub
End Class
