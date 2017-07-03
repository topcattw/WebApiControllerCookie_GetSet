Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web.Http

Public Class ValuesController
    Inherits ApiController

    ' GET api/values
    Public Function GetValues() As IEnumerable(Of String)
        Dim utilCookie As New CookieUtil

        '取得Cookie
        Dim getUToken As String = utilCookie.getCookie(Request, "UToken")

        '設定Cookie
        'Dim Cookie As HttpCookie = New HttpCookie("UToken", "UToken" & Format(Now, "yyyyMMddHHmmss"))
        'Cookie.Expires = DateAdd(DateInterval.Minute, 20, Now())
        'HttpContext.Current.Response.Cookies.Add(Cookie)
        Dim CookieValue As String = "UToken" & Format(Now, "yyyyMMddHHmmss")
        Dim CookieExpires As DateTime = DateAdd(DateInterval.Minute, 20, Now())

        utilCookie.setCookie("UToken", CookieValue, CookieExpires, "", "")

        Return New String() {"value1", "value2", getUToken}
    End Function

    ''' <summary>
    ''' 取得Cookie
    ''' </summary>
    ''' <param name="request">Request</param>
    ''' <param name="CookieName">Cookie的名字</param>
    ''' <returns></returns>
    Public Function getCookie(ByVal request As HttpRequestMessage, ByVal CookieName As String) As String
        Dim Rc As String = ""
        Dim cookie As CookieHeaderValue = request.Headers.GetCookies(CookieName).FirstOrDefault()
        If cookie IsNot Nothing Then
            Rc = cookie(CookieName).Value
        End If
        Return Rc
    End Function

    '' GET api/values/5
    'Public Function GetValue(ByVal id As Integer) As String
    '    Return "value"
    'End Function

    '' POST api/values
    'Public Sub PostValue(<FromBody()> ByVal value As String)

    'End Sub

    '' PUT api/values/5
    'Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    'End Sub

    '' DELETE api/values/5
    'Public Sub DeleteValue(ByVal id As Integer)

    'End Sub
End Class
