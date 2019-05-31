<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HotelManage.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>宾馆管理系统</title>
        <link rel="shortcut icon" />
    <link rel="stylesheet" href="./static/admin/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="./static/fonts/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="./static/ionicons/css/ionicons.min.css"/>
    <link rel="stylesheet" href="./static/admin/dist/css/AdminLTE.min.css"/>
    <link rel="stylesheet" href="./static/admin/plugins/iCheck/square/blue.css"/>
</head>
<body>
    
    <form id="form1" runat="server">
        
    


<body class="hold-transition login-page">
<div class="login-box">
    <div class="login-logo">
        <a href=""><b>宾馆管理系统</b></a>
    </div>
    <div class="login-box-body">
        <p class="login-box-msg"></p>
        
            <div class="form-group has-feedback">
                <input name="username" type="text" class="form-control" placeholder="请输入账号！"/>
                <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                <div class="col-md-12" id="input_user"></div>
            </div>
            <div class="form-group has-feedback">
                <input name="password" type="password" class="form-control" placeholder="请输入密码！"/>
                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                <div class="col-md-12" id="input_pwd"></div>
            </div>
            <div class="row">
                <div class="col-xs-8">
                </div>
                <div class="col-xs-4">
                    <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click1" class="btn btn-primary btn-block btn-flat"/>
                </div>
            </div>
        
    </div>
</div>
<script src="./static/admin/plugins/jQuery/jQuery-2.2.0.min.js"></script>
<script src="./static/admin/bootstrap/js/bootstrap.min.js"></script>
<script src="./static/admin/plugins/iCheck/icheck.min.js"></script>
</body>

    </form>


</body>
</html>
