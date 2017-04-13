<%@ Page Language="C#" Inherits="NewsAggregator.Default" %>
<%@ Import Namespace="System.ServiceModel.Syndication" %>
<%@ Import Namespace="NewsAggregator" %>
<!DOCTYPE html>
<html>
<head>
	<title>AgusCarry News</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
</head>
<body>

<form action="" runat="server">
    <div class="col-xs-2">
        <input type="text" class ="col-xs-4 form-control" placeholder="Search Here">
    </div>

    <div class="form-group">
        <div class="col-xs-1">
            <select class="form-control" id="sel1">
                <option>KMP</option>
                <option>BM</option>
                <option>REGEX</option>
            </select>
        </div>
    </div>
    <button type="submit" class="btn btn-default">Submit</button>
</form>

</body>
</html>
