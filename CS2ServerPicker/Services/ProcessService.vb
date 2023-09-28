Module ProcessService
    Public Function Create_Custom_CMD_Process() As Process
        Dim proc As Process = New Process()

        proc.StartInfo.FileName = "cmd.exe"
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardError = True
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.CreateNoWindow = True

        Return proc
    End Function
End Module
