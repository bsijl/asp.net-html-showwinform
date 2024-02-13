// The following sample code uses modern ECMAScript 6 features
// that aren't supported in Internet Explorer 11.
// To convert the sample for environments that do not support ECMAScript 6,
// such as Internet Explorer 11, use a transpiler such as
// Babel at http://babeljs.io/.
//
// See Es5-chat.js for a Babel transpiled version of the following code:
//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("http://localhost:8082/ChatHub")
//    .build();
var connection = $.hubConnection("http://localhost:8082/signalr", { useDefaultPath: false });
window.onload = () => {
    var proxy = connection.createHubProxy('ChatHub');
    proxy.on('SendMessage', function (name, message) {
        console.log(name + ' ' + message);
    });
    // 建立链接
    connection.start().done(function () {
        //$('#sendmessage').click(function () {
        console.log('服务器连接成功');
        let winInfo = {
            title: document.title,
            rect: getLocationInfo("video")
        }
        proxy.invoke('SendMessage', 'HtmlClinetOK',JSON.stringify(winInfo))
        //});
    })
        .fail(function () {
            console.log('服务器连接失败');
        });
};

document.getElementById("sendButton1").addEventListener("click", event => {
    connection.invoke("SendMessage", "HideWin", "video").catch(err => console.error(err));
    event.preventDefault();
});
document.getElementById("sendButton2").addEventListener("click", event => {
    var rect = getLocationInfo("video") 
   
    let videoRect = {
        'rect': rect,
    }
    connection.invoke("SendMessage", "ShowWin", JSON.stringify(rect)).catch(err => console.error(err));
    event.preventDefault();
});
// 获取位置信息
function getLocationInfo (id) {
    const elt = document.getElementById(id);
    var rect = elt.getBoundingClientRect()
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
            left: Math.floor(elt.getBoundingClientRect().left * getZoomScale()+6),
            top: Math.floor(elt.getBoundingClientRect().top * getZoomScale()) + (window.outerHeight - window.innerHeight)+15,
            width: Math.floor(elt.getBoundingClientRect().width * getZoomScale()),
            height: Math.floor(elt.getBoundingClientRect().height * getZoomScale()),
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
