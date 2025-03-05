Imports System.Net
Imports Newtonsoft.Json.Linq

Module VersionService
    Public Async Sub Version_Check()
        Try
            If Not My.Settings.VersionCheckOnStartup Or App.Debug Then
                Return
            End If

            Dim wClient As WebClient = New WebClient()

            ' github requires a user-agent header on non-browser request
            wClient.Headers.Set("User-Agent", "cs2-server-picker")

            Dim releasesRes As String = Await wClient.DownloadStringTaskAsync("https://api.github.com/repositories/649341649/releases")

            Dim releasesJsonArr As JArray = JArray.Parse(releasesRes)

            ' vb app assembly versioning has 4 components
            Dim latestReleaseVersion As String = releasesJsonArr(0).SelectToken("tag_name").ToString().Split("v")(1) + ".0"

            If Not latestReleaseVersion = App.ProductVersion Then
                Dim versionCheck As DialogResult = MessageBox.Show(App, "New version available! Go to releases?", "Version Check", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                If versionCheck = DialogResult.Yes Then
                    Process.Start("https://github.com/FN-FAL113/cs2-server-picker/releases")
                End If
            End If

            wClient.Dispose()
        Catch ex As Exception
            MessageBox.Show(App, "Failed to check for new version! Check your internet connection.", "Version Check", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Module
