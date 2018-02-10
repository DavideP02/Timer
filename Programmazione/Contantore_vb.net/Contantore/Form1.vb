Public Class Form1
    Dim sec As Integer = 0
    Dim min As Integer = 0
    Dim hour As Integer = 0
    Dim bool As String
    Dim dir As Boolean
    Dim file As Boolean


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Maximum = 60
        ProgressBar2.Maximum = 60
        ProgressBar3.Maximum = 24
        dir = Microsoft.VisualBasic.FileIO.FileSystem.DirectoryExists(".\file")
        If dir = False Then
            Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory(".\file")
        End If
        file = Microsoft.VisualBasic.FileIO.FileSystem.FileExists(".\file\bool.tub")
        If file = False Then
            Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(".\file\bool.tub", "0", False)
        End If
        bool = My.Computer.FileSystem.ReadAllText(".\file\bool.tub")
        If bool = "1" Then
            sec = My.Computer.FileSystem.ReadAllText(".\file\sec.tub")
            min = My.Computer.FileSystem.ReadAllText(".\file\min.tub")
            hour = My.Computer.FileSystem.ReadAllText(".\file\hour.tub")
        End If
        Secondi.Text = sec
        Minuti.Text = min
        Ore.Text = hour
        ProgressBar1.Value = sec
        ProgressBar2.Value = min
        ProgressBar3.Value = hour
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If sec < 59 Then
            sec = sec + 1
            Secondi.Text = sec
            ProgressBar1.Value = sec
        Else
            sec = 0
            If min < 59 Then
                min = min + 1
                ProgressBar2.Value = min
                Minuti.Text = min
            Else
                min = 0
                hour = hour + 1
                ProgressBar3.Value = hour
                Ore.Text = hour
            End If
            ProgressBar1.Value = sec
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "stop" Then
            Timer1.Stop()
            Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(".\file\sec.tub", sec, False)
            Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(".\file\min.tub", min, False)
            Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(".\file\hour.tub", hour, False)
            Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(".\file\bool.tub", "1", False)
            Button2.Text = "X"
        ElseIf Button2.Text = "X" Then
            Me.Close()
        End If
        
    End Sub
End Class
