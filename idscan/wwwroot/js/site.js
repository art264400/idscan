html,
body{
margin:0;
padding:0;
width:100%;
height:100%;
}

#prompt-form{
display:inline-block;
padding:5px5px5px70px;
width:200px;
border:1pxsolidblack;
background:whiteurl(https://en.js.cx/clipart/prompt.png)no-repeatleft5px;
vertical-align:middle;
}

#prompt-form-container{
position:fixed;
top:0;
left:0;
z-index:9999;
display:none;
width:100%;
height:100%;
text-align:center;
}

#prompt-form-container:before{
display:inline-block;
height:100%;
content:'';
vertical-align:middle;
}

#cover-div{
position:fixed;
top:0;
left:0;
z-index:9000;
width:100%;
height:100%;
background-color:gray;
opacity:0.3;
}

#prompt-forminput[name='text']{
display:block;
margin:5px;
width:180px;
}
