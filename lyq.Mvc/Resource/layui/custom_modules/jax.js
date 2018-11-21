layui.define(['layer'], function (e) {
    var layer = layui.layer;
    var $ = layui.$;
    //var loading = 0;
    $.ajaxSetup({
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        beforeSend: function () {
            //loading = layer.msg('数据请求中', { icon: 16, time: false });
        },
        error: function (XMLHttpRequest) {
            console.log('error');
            var status = XMLHttpRequest.status;
            var message = XMLHttpRequest.responseText;
            console.log(XMLHttpRequest);
            console.log(status);
            layer.alert(message, { title: status, icon: 15, closeBtn: 0 }, function (index) {
                console.log(index);
                if (status == 999) {
                    top.window.location = "/Account/Logout";
                }
                layer.close(index);
            });
        }
    });
    e('jax', {});
})