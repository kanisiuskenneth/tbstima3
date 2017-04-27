<%@ Page Language="C#" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>
<%@ Import Namespace="NewsAggregator" %>
<%@ Import Namespace="NewsAggregator.parser" %>



<!DOCTYPE html">
<html>
<head>
    <link rel="stylesheet" href="../Style/search.css">
    <link rel="icon" href="../asset/favicon.png">
    <title>SyndicateNews | Search</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

</head>
<body>
    <div class="content">
        <%
        string query = Request.QueryString["query"];
        string algo = Request.QueryString["algo"];

        foreach(News news in Global.newslist)
        {

            Response.Write("<a style='text-decoration: none;' target=_blank href="+news.link+">");
            Response.Write("<div class=item>");
                Response.Write("<img src="+news.imagelink+">");
                Response.Write("<span class='title'>"+news.title+"</span><br>");
                Response.Write("<span class=brief>"+news.summary+"</span><br>");
                Response.Write("<span class=source>"+"asd"+"</span>");
            Response.Write("</div>");
            Response.Write("</a>");

            }
        %>
    </div>
    <div class="header">
        <a href="../"><img src="../asset/logo.png"></a>
        <div class="form">
        <form action="search.aspx" method="get" runat="server">
            <input type="text" class ="text form-control" name="query" id="search" autofocus placeholder="Search Here">
            <select class="" id="select" class="form-control" name="algo">
                <option>KMP</option>
                <option>BM</option>
                <option>REGEX</option>
            </select>
            <button class="btn btn-primary"><i class="material-icons">search</i></button>
        </form>
        </div>
    </div>

        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous">
</script>
</body>
</html>
