/*
 * 	Additional function for forms.html
 *	Written by ThemePixels	
 *	http://themepixels.com/
 *
 *	Copyright (c) 2012 ThemePixels (http://themepixels.com)
 *	
 *	Built for Amanda Premium Responsive Admin Template
 *  http://themeforest.net/category/site-templates/admin-templates
 */

jQuery(document).ready(function () {

    ///// FORM TRANSFORMATION /////
    jQuery('input:checkbox, input:radio, select.uniformselect, input:file').uniform();


    ///// DUAL BOX /////
    var db = jQuery('#dualselect').find('.ds_arrow .arrow');	//get arrows of dual select
    var sel1 = jQuery('#dualselect select:first-child');		//get first select element
    var sel2 = jQuery('#dualselect select:last-child');			//get second select element

    sel2.empty(); //empty it first from dom.

    db.click(function () {
        var t = (jQuery(this).hasClass('ds_prev')) ? 0 : 1;	// 0 if arrow prev otherwise arrow next
        if (t) {
            sel1.find('option').each(function () {
                if (jQuery(this).is(':selected')) {
                    jQuery(this).attr('selected', false);
                    var op = sel2.find('option:first-child');
                    sel2.append(jQuery(this));
                }
            });
        } else {
            sel2.find('option').each(function () {
                if (jQuery(this).is(':selected')) {
                    jQuery(this).attr('selected', false);
                    sel1.append(jQuery(this));
                }
            });
        }
    });



    /// FORM VALIDATION /////
    jQuery("#form1").validate({
        rules: {
            Name: "required",
            Address: "required",
            ContactUserName: "required",
            ContactUserMobile: "required",
            FixedPhone: "required",
            Email: {
                required: true,
                email: true,
            }
        },
        messages: {
            Name: "请输入公司名称",
            Address: "请输入公司地址",
            ContactUserName: "请输入联系人",
            ContactUserMobile: "请输入联系人电话",
            FixedPhone: "请输入固定电话",
            Email: "请输入有效的Email地址"
        }
    });


    ///// TAG INPUT /////

    jQuery('#tags').tagsInput();


    ///// SPINNER /////

    jQuery("#spinner").spinner({ min: 0, max: 100, increment: 2 });


    ///// CHARACTER COUNTER /////

    jQuery("#textarea2").charCount({
        allowed: 120,
        warning: 20,
        counterText: 'Characters left: '
    });


    ///// SELECT WITH SEARCH /////
    jQuery(".chzn-select").chosen();

});