<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SuveriBidikmisi.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Survei Bidikmisi</title>
            <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500">
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="http://simukt.untidar.ac.id/assets/css/form-elements.css">
        <link rel="stylesheet" href="http://simukt.untidar.ac.id/assets/css/style.css">

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
            <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->

        <!-- Favicon and touch icons -->
        <link rel="shortcut icon" href="assets/ico/favicon.png">
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png">
        <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png">
        <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!-- Top content -->
        <div class="top-content">
            <!-- <div class="inner-bg"> -->
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong>SURVEY BIDIKMISI</strong> Login Form</h1>
                            <div class="description">
                                <p>
                                    This is a free responsive login form made with Bootstrap. 
                                    Download it on <a href="http://azmind.com"><strong>AZMIND</strong></a>, customize and use it as you like!
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3>Login to our site</h3>
                                    <p>Enter your username and password to log on:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-key"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                            <div class="form-bottom" method="post" accept-charset="utf-8">
                                    <div class="form-group">
                                        <label class="sr-only" for="form-username">Username</label>
                                        <%--<input type="text" name="form-username" placeholder="Username..." class="form-username form-control" id="Text1">--%>
                                        <asp:TextBox ID="TbUser" placeholder="Username..." CssClass="form-username form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="form-password">Password</label>
                                        <%--<input type="password" name="form-password" placeholder="Password..." class="form-password form-control" id="Password1">--%>
                                        <asp:TextBox ID="TbPass" placeholder="Password..." 
                                            CssClass="form-password form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <%--<button type="submit" class="btn">Sign in!</button>--%>
                                    <asp:Button ID="BtnLogin" CssClass="btn btn-danger" runat="server" 
                                        Text="Sign in!" onclick="BtnLogin_Click" />
                            </div> 
                            </div>
                        </div>
                    </div>
                    <!-- <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 social-login">
                            <h3>...or login with:</h3>
                            <div class="social-login-buttons">
                                <a class="btn btn-link-1 btn-link-1-facebook" href="#">
                                    <i class="fa fa-facebook"></i> Facebook
                                </a>
                                <a class="btn btn-link-1 btn-link-1-twitter" href="#">
                                    <i class="fa fa-twitter"></i> Twitter
                                </a>
                                <a class="btn btn-link-1 btn-link-1-google-plus" href="#">
                                    <i class="fa fa-google-plus"></i> Google Plus
                                </a>
                            </div>
                        </div>
                    </div> -->
                </div>
            <!-- </div> -->
        </div>


        <!-- Javascript -->
        <script src="http://simukt.untidar.ac.id/assets/js/jquery-1.11.1.min.js"></script>
        <script src="http://simukt.untidar.ac.id/assets/js/bootstrap.min.js"></script>
        <script src="http://simukt.untidar.ac.id/assets/js/jquery.backstretch.min.js"></script>
        <script src="http://simukt.untidar.ac.id/assets/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->    
    </div>
    </form>
</body>
</html>
