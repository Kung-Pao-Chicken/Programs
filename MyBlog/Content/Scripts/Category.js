$(document).ready(function () {
    var option;
    var catcontentid;
    var catid;
    var catcontentname;
    $(".inputdialogback").hide();

    $(".option,#add").click(function () {
        var sender = $(this);
        option = sender.attr("id");
        catcontentid = sender.parents('.listitem').attr('tag');
        catid = $("#catid").text();
        catcontentname = sender.parents('.listitem').children(".catcontentname").text();

        if (option == "delete") {
            $.post("/MyAdmin/CategoryPost", { "option": "delete", "catcontentid": catcontentid}, function (data, status) {
                sender.parents('.listitem').remove();
                alert("状态：" + data);
            });
        } else if (option == "add") {
            $(".inputdialogback").show();
            $(".fenlei").hide();

            $(".okbutton").click(function () {
                catcontentname = $(".catnametext").val();
                //catcontentlogo = $(".catcontentlogotext").val();
                catid = $("#catid").text();

                $(".inputdialogback").hide();
                $.post("/MyAdmin/CategoryPost", { "option": "add", "catcontentname": catcontentname, "catid": catid }, function (data, status) {
                    var str = data.split(",");
                    alert("状态：" + str[0]);
                    //sender.parents('form').append("<div class='listitem' tag='" + str[1] + "'><span class='listitemtitle'>" + catcontentname + "</span><span class='listitemlogo'>"+catcontentlogo+"</span><span class='listitemoption'><a class='option' id='delete' href='#'>删除</a></span><span class='listitemoption'><a class='option' id='update' href='#'>修改</a></span></div>");
                    location.reload();
                });
            });
        } else if (option == "update") {
            $(".catnametext").val(catcontentname);
            $(".catidtext").val(catid);

            $(".inputdialogback").show();
            $(".okbutton").click(function () {
                catcontentname = $(".catnametext").val();
                catid = $(".catidtext").val().split("-")[0];
                $(".inputdialogback").hide();
                $.post("/MyAdmin/CategoryPost", { "option": "update", "catcontentid": catcontentid, "catid": catid, "catcontentname": catcontentname }, function (data, status) {
                    alert("状态：" + data);
                    sender.parents(".listitem").children(".listitemtitle").text(catcontentname);
                    location.reload();
                });
            });
        }
        $(".cancelbutton").click(function () {
            $(".inputdialogback").hide();
            $(".okbutton").unbind("click");
            $(".fenlei").show();
        });
    });
});