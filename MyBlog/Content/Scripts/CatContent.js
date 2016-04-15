$(document).ready(function () {
    var option;
    var catcontentid;
    var acticletitle;
    var acticlecopyright;
    $(".inputdialogback").hide();

    $(".option,#add").click(function () {
        var sender = $(this);
        option = sender.attr("id");
        catcontentid = $("#catcontentid").text();
        acticletitle = sender.parents('.listitem').children(".listitemacticletitle").text();
        acticlecopyright = sender.parents('.listitem').children(".listitemacticlecopyright").text();
        acticleid = sender.parents('.listitem').attr('tag');

        if (option == "delete") {
            $.post("/MyAdmin/CatContentPost", { "option": "delete", "acticleid": acticleid }, function (data, status) {
                sender.parents('.listitem').remove();
                alert("状态：" + data);
            });
        } else if (option == "add") {
            $(".inputdialogback").show();
            $(".fenlei").hide();
            $(".okbutton").click(function () {
                acticletitle = $(".acticletitletext").val();
                acticlecopyright = $(".acticlecopyrighttext").val();
                $(".inputdialogback").hide();
                catcontentid = $("#catcontentid").text();
                $.post("/MyAdmin/CatContentPost", { "option": "add", "catcontentid": catcontentid, "acticletitle": acticletitle, "acticlecopyright": acticlecopyright }, function (data, status) {
                    alert("状态：" + data);
                    //sender.parents('form').append("<tr class='listitem' tag='" + str[1] + "'><td class='listitemtitle'>" + catname + "</td><td class='listitemcatid'>" + catid + "</td><td class='listitemoption'><a class='option' id='update' href='#'>修改</a><a class='option' id='delete' href='#'>删除</a></td></tr>");
                    location.reload();
                });
            });
        } else if (option == "update") {
            $(".fenlei").show();
            $(".acticletitletext").val(acticletitle);
            $(".acticlecopyrighttext").val(acticlecopyright);
            $(".catcontentidtext").val(catcontentid);
            $(".inputdialogback").show();
            $(".okbutton").click(function () {
                acticletitle = $(".acticletitletext").val();
                acticlecopyright = $(".acticlecopyrighttext").val();
                catcontentid = $(".catcontentidtext").val().split("-")[0];
                $(".inputdialogback").hide();
                $.post("/MyAdmin/CatContentPost", { "option": "update", "acticletitle": acticletitle, "acticlecopyright": acticlecopyright, "catcontentid": catcontentid, "acticleid": acticleid }, function (data, status) {
                    alert("状态：" + data);
                    //sender.parents(".listitem").children(".listitemtitle").text(catname);
                    location.reload();
                });
            });
        }
        $(".cancelbutton").click(function () {
            $(".inputdialogback").hide();
            $(".okbutton").unbind("click");
        });
    });
});