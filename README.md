# asp.net-html-showwinform
使用asp.net在html页面上显示windows窗口,播放rtsp视频
本项目我只是将想法写了出来，很多没有实现，希望有兴趣的或是愿意帮助和改进的一起完善
代码分为2个部分：HttpServer HttpClinet
HttpServer使用signalR-2.4.3版本，因为asp.net不是asp.net core好像只能使用这个版本。它的基本功能是与html页面通信，生成播放器窗口，并嵌入到目前流行的浏览器中，目前阶段只能嵌入到Edge浏览器中,谷歌和360不行，不是没嵌入进去，而是嵌入后不显示。播放窗口可以实现2*2 4*4等布局。
HttpClinet是模拟Web服务器，方便调试，实际部署只有静态html页面和js文件有用
