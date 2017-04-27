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
    <link rel="stylesheet" href="../Style/search.css">
    <link rel="icon" href="../asset/favicon.png">
    <title>SyndicateNews | Search</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <script>
        function redirect(x) {
            alert(x);
            window.location.assign(x);
        }
    </script>
</head>
<body>
    <div class="content">
      <a class=item>
          <div>
              <img class="itemhead" src="something.jpg"/>
              <span class="title"> SOMEHTINF</span>
          </div>
      </a>
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

          try
          {
              foreach (var res in Global.newslist)
              {
                  Response.Write(res.description);
              }
          }
          catch (Exception e)
          {
              Response.Write("News Not Found");
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
            <button class="btn btn-primary">search</button>
        </form>
        </div>
    </div>

        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous">
</script>
</body>
</html>
