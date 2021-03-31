#推廣c#,所以公開
程式參考youtube，有問題可以問，但我不一定即時回，也不是每天開github  
key word：iis、oauth2、c#、mvc、api、authorization、token、認證、實作、自建oauth、Implement OAuth 2.0 Authorization, ASP.NET web API、 
  
# owinserver
OAuth  
參考https://www.youtube.com/watch?v=TsH3BzIPzeU  
postman  
https://localhost:44302/token  
x-www-form-urlencoded  
username xxx  
password xxx  
grant_type password  
post!!

增加  get User  
參考：https://www.youtube.com/watch?v=etJapM77ksw  
postman  
https://localhost:44302/api/User  
header 增加
Authorization Basic {輸入你的token值，不用含大刮號}  
↓
header欄位填上：Authorization  
Value欄位填上： Basic {token值}  
post!!
