Imports System.IO

Module ErrorService
    Public Sub Log_Exception_To_File(exception As Exception, errorFrom As String)
        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "error_" + DateTimeOffset.Now.ToUnixTimeSeconds.ToString() + ".txt",
                          errorFrom + Environment.NewLine + exception.Message)
    End Sub
End Module
