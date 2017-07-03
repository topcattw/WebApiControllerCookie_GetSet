Imports System.Net.Http
Imports System.Net.Http.Headers

Public Class CookieUtil

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

    Public Sub setCookie(ByVal CookieName As String, ByVal CookieValue As String, ByVal CookieExpires As DateTime, ByVal CookieDomain As String, ByVal CookiePath As String)
        '設定Cookie
        Dim Cookie As HttpCookie = New HttpCookie("UToken", "UToken" & Format(Now, "yyyyMMddHHmmss"))
        'Cookie.Expires = DateAdd(DateInterval.Minute, 20, Now())
        With Cookie
            .Expires = CookieExpires
            If CookieDomain <> "" Then
                .Domain = CookieDomain
            End If
            If CookiePath <> "" Then
                .Path = CookiePath
            End If
        End With
        HttpContext.Current.Response.Cookies.Add(Cookie)
    End Sub


End Class
