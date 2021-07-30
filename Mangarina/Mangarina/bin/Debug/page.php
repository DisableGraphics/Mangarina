<head>
    <title> Mangarina </title>
<script>$(document).ready(function(){
   //your code here
    document.onload = function(){
    window.scrollTo(0,0);
}
});
</script>
</head>
<body style="background-color: #151515; color: #F0F0F0;" onload="window.scrollTo(0,0)">
</body>
<style>
a {
    color:antiquewhite;
}
a:link {
    color: #DDDDDD;
    text-decoration: none;

}
a:visited {
    color: #FFDDFF;
    text-decoration: none;

}
a:hover {
    color: #FFFF77;
    text-decoration: underline;
}
img {
    width: 98%;
    vertical-align: middle;
    padding: 5px;
}
img.hover {
    box-shadow: 0 0 2px 1px rgba(200, 200, 200, 0.5);
}
/* Clear floats after image containers */
.row::after {
  content: "";
  clear: both;
  display: table;
}
</style>
<?php
    header("Location: file:///home/disablegraphics/Projects/Mangarina/Mangarina/bin/Debug/page.html");    
    $filelist = glob("tmp/*");
    for ($i = 0; $i < (count(scandir("tmp"))); $i++ ) {
            echo '<div class="row">';
            $file = $filelist[$i];
            printf("<img src=%s>", "$file");
            echo '<br>';
            echo '</div>';
    }
?>
