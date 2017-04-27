<!--
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>
<%@ Import Namespace="NewsAggregator" %>
<%@ Import Namespace="NewsAggregator.parser" %>
<%@ Import Namespace="searcher" %>
!-->

<!DOCTYPE html">
<html>
<head>
    <link rel="stylesheet" href="../style/search.css">
    <link rel="icon" href="../asset/favicon.png">
    <title>SyndicateNews | Search</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <script>
        function redirect(x) {
            //alert(x);
            window.open(x,"_blank");
        }
    </script>
</head>
<body>
    <div class="content">
      <%

          string pattern = Request.QueryString["query"];
          string algo = Request.QueryString["algo"];
          List<Tuple<int, String>> hsl;
          Console.WriteLine(pattern);
          Console.WriteLine(algo);
          if (algo == "KMP")
          {
              Console.Write("Searching with KMP");
              KMP kmp = new KMP("","");
              hsl = kmp.SearchAllNews(Global.newslist, pattern);
              Console.Write("Searching done");

          }
          else if (algo == "BM")
          {
              BoyerMoore bm = new BoyerMoore("", "");
              hsl = bm.SearchAllNews(Global.newslist, pattern);
          }
          else
          {
              RegexSearcher regex = new RegexSearcher("","");
              hsl = regex.SearchAllNews(Global.newslist, pattern);
          }

          if (hsl.Count == 0)
          {
              Response.Write("Not Found");
          }
          else
          {
              foreach (var Item in hsl)
              {
                  Response.Write("<div class=item onclick=redirect('"+Global.newslist[Item.Item1].link+"')>");
                      Response.Write("<img class=itemhead src="+Global.newslist[Item.Item1].imagelink+">");
                      Response.Write("<span class=title align=center>"+Global.newslist[Item.Item1].title+"</span>");
                      Response.Write("<span class=itemfoot>"+Global.newslist[Item.Item1].source+
                                     " <font size=1><small>"+Global.newslist[Item.Item1].pubdate
                                     +"</small></font>"+"</span>");
                      Response.Write("<div class=content><p class=summary align=center><font size=4>"
                                     +Global.newslist[Item.Item1].summary+"</font></p>" );
                      Response.Write("<p class=foundat align=center>" +
                                     "<font size=1>found at: ..."+Item.Item2+"...</font></p></div>");
                  Response.Write("</div>");
              }
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
            <button class="btn btn-primary"><i class="glyphicon glyphicon-search"></i></button>
        </form>
        </div>
    </div>

        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous">
</script>
</body>
</html>
