//以下示例代码使用了现代的ECMAScript 6功能，这些功能在Internet Explorer 11中不受支持。
//为了将示例转换为不支持ECMAScript 6的环境（例如Internet Explorer 11），请使用转译器，如http://babeljs.io/上的Babel。
//请参阅Es5 - chat.js，其中包含了上述代码的Babel转译版本。
var connection = $.hubConnection("http://localhost:8082/signalr", { useDefaultPath: false });
var proxy = connection.createHubProxy('ChatHub');
window.onload = () => {
    //#region 接收消息      
    proxy.on('SendMessage', function (opt, message) {
        switch (opt) {
            case "HtmlClientOK":
                let winInfo = {
                    title: document.title,
                    rect: getLocationInfo("video")
                }
                $("#message").html("服务器连接成功并显示窗口");
                proxy.invoke('SendMessage', 'HtmlClinetOK', JSON.stringify(winInfo))
                SetZoomScale();
                break;
            default:
        }
    });
    //#endregion
    //#region connection事件
    // 建立链接
    connection.start().done(function () {
        //这里的优先级没有 proxy.on 高！信息都返回了，才运行到这里
        //proxy.invoke('SendMessage', 'HtmlClinetOK', JSON.stringify(winInfo))
    })
        .fail(function () {
            $("#message").html("服务器连接失败");
        });
    connection.error((error) => {//与服务器断开，等等吧，只要出错了
        $("#message").html("服务器连接断开");
    })

    connection.reconnected(() => {//没测出来--页面在没有关闭的情况下，HttpServer重启后，会重新连接
        $("#message").html("服务器重新连接上服务器");
    })

    connection.disconnected(() => {//与服务器连接失败，优先级低于.fail
        //console.log('disconnected')
    })

    connection.received((data) => {//连接后最先收到消息，数组形式的
        //console.log('received')
        //console.log(data)
    })

    connection.connectionSlow(() => {//没测出来--断过一次，好像是超时--英文含义是连接速度慢
        $("#message").html("与服务器的通信有点慢啊");
    })
    //#endregion
};

window.onresize = (hb, e) => {//这里不能放代码，柱塞太严重
    
}
function SetZoomScale() {
    setTimeout(SetZoomScale, 450); 
    let winInfo = {
        title: document.title,
        rect: getLocationInfo("video")
    }
    proxy.invoke('SendMessage', 'SetZoomScale', JSON.stringify(winInfo))
}
document.getElementById("sendButton1").addEventListener("click", event => {
    proxy.invoke("SendMessage", "HideWin", "");
});
document.getElementById("sendButton2").addEventListener("click", event => {

    proxy.invoke("SendMessage", "ShowWin", "");
});
// 获取位置信息--这里的不准确，该怎么调整？但是这段代码在另外一个程序里运行没问题
function getLocationInfo(id) {
    const elt = document.getElementById(id);
    var rect = elt.getBoundingClientRect()
    let top = elt.offsetTop
    var ua = navigator.userAgent;
    if (/firefox/i.test(ua)) {
        const item = screen.availHeight === outerHeight ? 0 : outerHeight === innerHeight ? 0 : outerHeight > innerHeight ? -8 : 8;
        return {
            left: Math.floor(screenX + elt.getBoundingClientRect().left * getZoomScale()),
            top: Math.floor(screenY + (outerHeight - innerHeight * getZoomScale()) + elt.getBoundingClientRect().top * getZoomScale() + item),
            width: Math.floor(elt.getBoundingClientRect().width * getZoomScale()),
            height: Math.floor(elt.getBoundingClientRect().height * getZoomScale()),
            screenLeft: Math.floor(window.screenLeft)
        };
    } else {
        return {
            left: Math.floor(elt.getBoundingClientRect().left * getZoomScale() +6),//* getZoomScale()
            top: Math.floor(elt.getBoundingClientRect().top * getZoomScale() + (window.outerHeight - window.innerHeight)+15),//差的这个15是什么？
            width: Math.floor(elt.getBoundingClientRect().width * getZoomScale()),//  * getZoomScale()
            height: Math.floor(elt.getBoundingClientRect().height * getZoomScale()),// * getZoomScale()
            screenLeft: Math.floor(window.screenLeft)
        };
    }
};
function getZoomScale() {
    var ratio = 0;
    var screen = window.screen;
    var ua = navigator.userAgent.toLowerCase();
    if (window.devicePixelRatio !== undefined) {
        undefined
        ratio = window.devicePixelRatio;
    } else if (~ua.indexOf('msie')) {
        undefined
        if (screen.deviceXDPI && screen.logicalXDPI) {
            undefined
            ratio = screen.deviceXDPI / screen.logicalXDPI;
        }
    } else if (window.outerWidth !== undefined && window.innerWidth !== undefined) {
        undefined
        ratio = window.outerWidth / window.innerWidth;
    }
    return ratio;
}
