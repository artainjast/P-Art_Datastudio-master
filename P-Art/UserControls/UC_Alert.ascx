<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Alert.ascx.cs" Inherits="P_Art.UserControls.UC_Alert" %>
<div style="display: none;" class="payesh-main-alert">
    <div class="ajs-dimmer"></div>
    <div class="ajs-modal" tabindex="0">
        <div class="payesh-alert">
            <div class="ajs-commands">
                <button class="ajs-close" onclick="return false;"></button>
            </div>
            <div class="alert-header">
                <span class="alert-title">عنوان هشدار</span>
            </div>
            <div class="alert-body">
                <p class="alert-content">متن کاملی از هشدار</p>
            </div>
        </div>
    </div>
</div>
<script>
    $('.ajs-close').click(function () {
        CloseAlert();
    });
    function OpenAlert(title, body) {
        $('.alert-title').html(title);
        $('.alert-content').html(body);
        $('.payesh-main-alert').css('display', 'block');
    }
    function CloseAlert() {
        $('.alert-title').html("");
        $('.alert-content').html("");
        $('.payesh-main-alert').css('display', 'none');
    }
</script>





