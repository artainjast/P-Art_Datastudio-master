<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PArt.Pages.P_Art.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>سیستم پایش اخبار | News Monitoring System</title>
    <!-- Panel style sheet class-->
    <link href="Styles/PanelStyle.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />
    <script src="../../Scripts/jquery-3.3.1.min.js"></script>
    <!-- FontAwesome css for used icon from fontawesome.com  import from our server-->
    <link href="../Styles/FontAwesome/web-fonts-with-css/css/fontawesome-all.min.css" rel="stylesheet" />


    <style>
        /*Page pre load spinner*/
        #loader {
            transition: all 0.3s ease-in-out;
            opacity: 1;
            visibility: visible;
            position: fixed;
            height: 100vh;
            width: 100%;
            background: #fff;
            z-index: 90000;
        }

            #loader.fadeOut {
                opacity: 0;
                visibility: hidden;
            }



        .spinner {
            width: 40px;
            height: 40px;
            position: absolute;
            top: calc(50% - 20px);
            left: calc(50% - 20px);
            background-color: #333;
            border-radius: 100%;
            -webkit-animation: sk-scaleout 1.5s infinite ease-in-out;
            animation: sk-scaleout 1.5s infinite ease-in-out;
        }

        @-webkit-keyframes sk-scaleout {
            0% {
                -webkit-transform: scale(0);
            }

            100% {
                -webkit-transform: scale(2.0);
                opacity: 0;
            }
        }

        @keyframes sk-scaleout {
            0% {
                -webkit-transform: scale(0);
                transform: scale(0);
            }

            100% {
                -webkit-transform: scale(2.0);
                transform: scale(2.0);
                opacity: 0;
            }
        }
        /*-----------------------------*/
    </style>


</head>
<body>
    <form runat="server">
        <div id='loader'>
            <div class="spinner"></div>
        </div>

        <script>
            window.addEventListener('load', () => {
                const loader = document.getElementById('loader');
                setTimeout(() => {
                    loader.classList.add('fadeOut');
                }, 300);
            });
        </script>

        <div id="main-container" class="login-container">

            <!-- ## ABOUT US TILE begins here ## -->
            <div class="login-input" data-target="#about-modal">
                <img class="loginLogo" src="/Pages/P-Art/Images/project-logo.png" />
                <asp:TextBox ID="txt_UserName" runat="server" placeholder="نام کاربری" CssClass="textbox" Style="background: #fff"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rq_UserName"
                    runat="server" ControlToValidate="txt_UserName" ErrorMessage="*" ForeColor="Red" Display="Dynamic" />
                <br />
                <asp:TextBox ID="txt_Password" TextMode="Password" runat="server" placeholder="رمز ورود" CssClass="textbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rq_Password"
                    runat="server" ControlToValidate="txt_Password" ErrorMessage="*" ForeColor="Red" Display="Dynamic" />
                <br />
                <asp:Button runat="server" ID="btn_Login" CausesValidation="false" OnClick="btn_Login_Click" Text="ورود" CssClass="btn btn-info cur-p" />
                <br />
                <asp:Label runat="server" ID="ltMsg" CssClass="login-message" ></asp:Label>


            </div>
            <!-- ## ABOUT US TILE ends here ## -->

        </div>


    </form>


</body>
</html>

