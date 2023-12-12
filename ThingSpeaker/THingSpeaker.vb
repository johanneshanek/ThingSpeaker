
Imports System.Net

Public Class ThingSpeaker

    Private domain As String

    Public Sub New(writekey As String)
        domain = "https://api.thingspeak.com/update?api_key=" & writekey
    End Sub

    Public Sub UpdateChannel(Channels() As Channel)
        Dim uri As String = domain
        For Each c As Channel In Channels
            uri &= c.ToString
        Next
        Dim request As HttpWebRequest = WebRequest.Create(uri)
        Dim response As HttpWebResponse = request.GetResponse
        If Not response.StatusCode = HttpStatusCode.OK Then MsgBox(response.StatusDescription)
    End Sub

    Public Class Channel

        Public Number As Integer
        Public Value As Double

        Public Sub New(number As Integer, value As Double)
            Me.Number = number
            Me.Value = value
        End Sub

        Public Overrides Function ToString() As String
            Return "&field" & Number & "=" & Value
        End Function
    End Class

End Class
