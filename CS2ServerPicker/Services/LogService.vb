Imports System.IO

Module LogService
    Public Sub Log_To_File(text As String, Optional fileName As String = "")
        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory +
                           IIf(Not fileName = "", fileName, "log_" + DateTimeOffset.Now.ToUnixTimeSeconds.ToString()) + ".txt",
                           text + Environment.NewLine)
    End Sub

    Public Sub Log_Exception_To_File(exception As Exception, errorFrom As String, Optional fileName As String = "")
        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory +
                           IIf(Not fileName = "", fileName, "error_" + DateTimeOffset.Now.ToUnixTimeSeconds.ToString()) + ".txt",
                           errorFrom + Environment.NewLine + exception.Message)
    End Sub
End Module
