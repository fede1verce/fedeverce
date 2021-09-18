gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.workwithplusmasterpage', false, function () {
   this.ServerClass =  "wwpbaseobjects.workwithplusmasterpage" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.IsMasterPage=true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
      this.AV15DVelop_Menu=gx.fn.getControlValue("vDVELOP_MENU_MPAGE") ;
      this.AV17Breadcrumb=gx.fn.getControlValue("vBREADCRUMB_MPAGE") ;
   };
   this.Validv_Pickerdummyvariable=function()
   {
      return this.validCliEvt("Validv_Pickerdummyvariable", 0, function () {
      try {
         var gxballoon = gx.util.balloon.getNew("vPICKERDUMMYVARIABLE_MPAGE");
         this.AnyError  = 0;
         if ( ! ( (new gx.date.gxdate('').compare(this.AV22PickerDummyVariable)===0) || new gx.date.gxdate( this.AV22PickerDummyVariable ).compare( gx.date.ymdtod( 1753, 1, 1) ) >= 0 ) )
         {
            try {
               gxballoon.setError("Campo Picker Dummy Variable fuera de rango");
               this.AnyError = gx.num.trunc( 1 ,0) ;
            }
            catch(e){}
         }

      }
      catch(e){}
      try {
          if (gxballoon == null) return true; return gxballoon.show();
      }
      catch(e){}
      return true ;
      });
   }
   this.e110n1_client=function()
   {
      this.clearMessages();
      this.callUrl("https://www.linkedin.com/company/ssumar-group/");
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e120n1_client=function()
   {
      this.clearMessages();
      this.callUrl("https://www.linkedin.com/company/ssumar-group/");
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e130n1_client=function()
   {
      this.clearMessages();
      this.callUrl("https://www.linkedin.com/company/ssumar-group/");
      this.refreshOutputs([]);
      this.OnClientEventEnd();
      return gx.$.Deferred().resolve();
   };
   this.e170n2_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e180n2_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,84,85,87,88,90,91,93,94,95,96];
   this.GXLastCtrlId =96;
   this.UCMENU_MPAGEContainer = gx.uc.getNew(this, 20, 0, "DVelop_DVHorizontalMenu", "UCMENU_MPAGEContainer", "Ucmenu", "UCMENU_MPAGE");
   var UCMENU_MPAGEContainer = this.UCMENU_MPAGEContainer;
   UCMENU_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCMENU_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCMENU_MPAGEContainer.setProp("Cls", "Cls", "slimmenu RegularBackgroundColorOption", "str");
   UCMENU_MPAGEContainer.addV2CFunction('AV15DVelop_Menu', "vDVELOP_MENU_MPAGE", 'SetMenu');
   UCMENU_MPAGEContainer.addC2VFunction(function(UC) { UC.ParentObject.AV15DVelop_Menu=UC.GetMenu();gx.fn.setControlValue("vDVELOP_MENU_MPAGE",UC.ParentObject.AV15DVelop_Menu); });
   UCMENU_MPAGEContainer.setProp("CollapsedTitle", "Collapsedtitle", "Ssumar Group", "str");
   UCMENU_MPAGEContainer.setProp("ResizeWidth", "Resizewidth", "767", "str");
   UCMENU_MPAGEContainer.setProp("Code", "Code", "", "char");
   UCMENU_MPAGEContainer.setProp("MenuType", "Menutype", "Regular", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionEnabled", "Moreoptionenabled", true, "bool");
   UCMENU_MPAGEContainer.setProp("MoreOptionType", "Moreoptiontype", "MenuOption", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionCaption", "Moreoptioncaption", "WWP_More", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionIcon", "Moreoptionicon", "fa fa-bars", "str");
   UCMENU_MPAGEContainer.setProp("MoreOptionShowIconsOnInnerOptions", "Moreoptionshowiconsoninneroptions", false, "bool");
   UCMENU_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   UCMENU_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCMENU_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCMENU_MPAGEContainer);
   this.UCMESSAGE_MPAGEContainer = gx.uc.getNew(this, 83, 0, "DVelop_DVMessage", "UCMESSAGE_MPAGEContainer", "Ucmessage", "UCMESSAGE_MPAGE");
   var UCMESSAGE_MPAGEContainer = this.UCMESSAGE_MPAGEContainer;
   UCMESSAGE_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCMESSAGE_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCMESSAGE_MPAGEContainer.setProp("Width", "Width", "300", "str");
   UCMESSAGE_MPAGEContainer.setProp("MinHeight", "Minheight", "16", "str");
   UCMESSAGE_MPAGEContainer.setProp("StylingType", "Stylingtype", "fontawesome", "str");
   UCMESSAGE_MPAGEContainer.setProp("DefaultMessageType", "Defaultmessagetype", "notice", "str");
   UCMESSAGE_MPAGEContainer.setProp("StopOnError", "Stoponerror", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("TitleEscape", "Titleescape", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("TextEscape", "Textescape", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("ChangeNewLinesToBRs", "Changenewlinestobrs", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Hide", "Hide", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("DelayUntilHide", "Delayuntilhide", 8000, "num");
   UCMESSAGE_MPAGEContainer.setProp("MouseHideReset", "Mousehidereset", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("MessageAdditionalClasses", "Messageadditionalclasses", "", "str");
   UCMESSAGE_MPAGEContainer.setProp("MessageCornerClass", "Messagecornerclass", "", "str");
   UCMESSAGE_MPAGEContainer.setProp("Shadow", "Shadow", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Opacity", "Opacity", "1", "str");
   UCMESSAGE_MPAGEContainer.setProp("StackVerticalFirstPos", "Stackverticalfirstpos", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("StackHorizontalFirstPos", "Stackhorizontalfirstpos", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("StackVerticalSpacing", "Stackverticalspacing", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("StackHorizontalSpacing", "Stackhorizontalspacing", 15, "num");
   UCMESSAGE_MPAGEContainer.setProp("EffectIn", "Effectin", "fade", "str");
   UCMESSAGE_MPAGEContainer.setProp("EffectOut", "Effectout", "fade", "str");
   UCMESSAGE_MPAGEContainer.setProp("AnimationSpeed", "Animationspeed", 600, "num");
   UCMESSAGE_MPAGEContainer.setProp("StartPosition", "Startposition", "TopRight", "str");
   UCMESSAGE_MPAGEContainer.setProp("NextMessagePosition", "Nextmessageposition", "down", "str");
   UCMESSAGE_MPAGEContainer.setProp("Closer", "Closer", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("CloserHover", "Closerhover", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Sticker", "Sticker", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("StickerHover", "Stickerhover", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("LabelCloseButton", "Labelclosebutton", "Close", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelStickButton", "Labelstickbutton", "Stick", "str");
   UCMESSAGE_MPAGEContainer.setProp("showEvenOnNonblock", "Showevenonnonblock", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("NonBlock", "Nonblock", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("NonBlockOpacity", "Nonblockopacity", ".2", "str");
   UCMESSAGE_MPAGEContainer.setProp("EnableHistory", "Enablehistory", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Menu", "Menu", false, "bool");
   UCMESSAGE_MPAGEContainer.setProp("FixedMenu", "Fixedmenu", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("MaxOnScreen", "Maxonscreen", "Infinity", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelRedisplay", "Labelredisplay", "Redisplay", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelAll", "Labelall", "All", "str");
   UCMESSAGE_MPAGEContainer.setProp("LabelLast", "Labellast", "Last", "str");
   UCMESSAGE_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   UCMESSAGE_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCMESSAGE_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCMESSAGE_MPAGEContainer);
   this.UCTOOLTIP_MPAGEContainer = gx.uc.getNew(this, 86, 0, "BootstrapTooltip", "UCTOOLTIP_MPAGEContainer", "Uctooltip", "UCTOOLTIP_MPAGE");
   var UCTOOLTIP_MPAGEContainer = this.UCTOOLTIP_MPAGEContainer;
   UCTOOLTIP_MPAGEContainer.setProp("Class", "Class", "", "char");
   UCTOOLTIP_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   UCTOOLTIP_MPAGEContainer.setProp("ClassSelector", "Classselector", "BootstrapTooltip", "str");
   UCTOOLTIP_MPAGEContainer.setProp("DefaultPosition", "Defaultposition", "bottom", "str");
   UCTOOLTIP_MPAGEContainer.setProp("LabelsShowDelay", "Labelsshowdelay", 300, "num");
   UCTOOLTIP_MPAGEContainer.setProp("ButtonsShowDelay", "Buttonsshowdelay", 300, "num");
   UCTOOLTIP_MPAGEContainer.setProp("InputsShowDelay", "Inputsshowdelay", 300, "num");
   UCTOOLTIP_MPAGEContainer.setProp("ImagesShowDelay", "Imagesshowdelay", 0, "num");
   UCTOOLTIP_MPAGEContainer.setProp("HideDelay", "Hidedelay", 0, "num");
   UCTOOLTIP_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   UCTOOLTIP_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   UCTOOLTIP_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(UCTOOLTIP_MPAGEContainer);
   this.WWPUTILITIES_MPAGEContainer = gx.uc.getNew(this, 89, 0, "DVelop_WorkWithPlusUtilities", "WWPUTILITIES_MPAGEContainer", "Wwputilities", "WWPUTILITIES_MPAGE");
   var WWPUTILITIES_MPAGEContainer = this.WWPUTILITIES_MPAGEContainer;
   WWPUTILITIES_MPAGEContainer.setProp("Class", "Class", "", "char");
   WWPUTILITIES_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   WWPUTILITIES_MPAGEContainer.setProp("EnableAutoUpdateFromDocumentTitle", "Enableautoupdatefromdocumenttitle", false, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableFixObjectFitCover", "Enablefixobjectfitcover", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableFloatingLabels", "Enablefloatinglabels", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("EnableUpdateRowSelectionStatus", "Enableupdaterowselectionstatus", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("CurrentTab_ReturnUrl", "Currenttab_returnurl", "", "char");
   WWPUTILITIES_MPAGEContainer.setProp("EnableConvertComboToBootstrapSelect", "Enableconvertcombotobootstrapselect", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnResizing", "Allowcolumnresizing", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnReordering", "Allowcolumnreordering", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnDragging", "Allowcolumndragging", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("AllowColumnsRestore", "Allowcolumnsrestore", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("RestoreColumnsIconClass", "Restorecolumnsiconclass", "fas fa-undo", "str");
   WWPUTILITIES_MPAGEContainer.setProp("UpdateButtonText", "Updatebuttontext", "WWP_ColumnsSelectorButton", "str");
   WWPUTILITIES_MPAGEContainer.setProp("AddNewOption", "Addnewoption", "WWP_AddNewOption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("OnlySelectedValues", "Onlyselectedvalues", "WWP_OnlySelectedValues", "str");
   WWPUTILITIES_MPAGEContainer.setProp("MultipleValuesSeparator", "Multiplevaluesseparator", ", ", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SelectAll", "Selectall", "WWP_SelectAll", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SortASC", "Sortasc", "WWP_TSSortASC", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SortDSC", "Sortdsc", "WWP_TSSortDSC", "str");
   WWPUTILITIES_MPAGEContainer.setProp("AllowGroupText", "Allowgrouptext", "WWP_GroupByOption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("FixLeftText", "Fixlefttext", "WWP_TSFixLeft", "str");
   WWPUTILITIES_MPAGEContainer.setProp("FixRightText", "Fixrighttext", "WWP_TSFixRight", "str");
   WWPUTILITIES_MPAGEContainer.setProp("LoadingData", "Loadingdata", "WWP_TSLoading", "str");
   WWPUTILITIES_MPAGEContainer.setProp("CleanFilter", "Cleanfilter", "WWP_TSCleanFilter", "str");
   WWPUTILITIES_MPAGEContainer.setProp("RangeFilterFrom", "Rangefilterfrom", "WWP_TSFrom", "str");
   WWPUTILITIES_MPAGEContainer.setProp("RangeFilterTo", "Rangefilterto", "WWP_TSTo", "str");
   WWPUTILITIES_MPAGEContainer.setProp("RangePickerInviteMessage", "Rangepickerinvitemessage", "WWP_TSRangePickerInviteMessage", "str");
   WWPUTILITIES_MPAGEContainer.setProp("NoResultsFound", "Noresultsfound", "WWP_TSNoResults", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SearchButtonText", "Searchbuttontext", "WWP_TSSearchButtonCaption", "str");
   WWPUTILITIES_MPAGEContainer.setProp("SearchMultipleValuesButtonText", "Searchmultiplevaluesbuttontext", "WWP_FilterSelected", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorFixedLeftCategory", "Columnselectorfixedleftcategory", "WWP_ColumnSelectorFixedLeftCategory", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorFixedRightCategory", "Columnselectorfixedrightcategory", "WWP_ColumnSelectorFixedRightCategory", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorNotFixedCategory", "Columnselectornotfixedcategory", "WWP_ColumnSelectorNotFixedCategory", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorFixedEmpty", "Columnselectorfixedempty", "WWP_ColumnSelectorFixedEmpty", "str");
   WWPUTILITIES_MPAGEContainer.setProp("ColumnSelectorRestoreTooltip", "Columnselectorrestoretooltip", "WWP_SelectColumns_RestoreDefault", "str");
   WWPUTILITIES_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   WWPUTILITIES_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   WWPUTILITIES_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(WWPUTILITIES_MPAGEContainer);
   this.WWPDATEPICKER_MPAGEContainer = gx.uc.getNew(this, 92, 0, "WWP_DatePicker_UC", "WWPDATEPICKER_MPAGEContainer", "Wwpdatepicker", "WWPDATEPICKER_MPAGE");
   var WWPDATEPICKER_MPAGEContainer = this.WWPDATEPICKER_MPAGEContainer;
   WWPDATEPICKER_MPAGEContainer.setProp("Class", "Class", "", "char");
   WWPDATEPICKER_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   WWPDATEPICKER_MPAGEContainer.setProp("MinYear", "Minyear", 1970, "num");
   WWPDATEPICKER_MPAGEContainer.setProp("MaxYear", "Maxyear", 2040, "num");
   WWPDATEPICKER_MPAGEContainer.setProp("Style", "Style", "Light", "str");
   WWPDATEPICKER_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   WWPDATEPICKER_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   WWPDATEPICKER_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   this.setUserControl(WWPDATEPICKER_MPAGEContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"TABLEHEADERFIXWIDTH",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"TABLEHEADERCELL",grid:0};
   GXValidFnc[12]={ id: 12, fld:"TABLEHEADER",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"LOGOHEADER",grid:0};
   GXValidFnc[15]={ id: 15, fld:"LOGOSTICKYMENUCELL",grid:0};
   GXValidFnc[16]={ id: 16, fld:"LOGOFORSTICKYMENU",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TABLEUSERROLE",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"",grid:0};
   GXValidFnc[22]={ id: 22, fld:"TOPRIGHTFIXEDELEMENTS",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"UNNAMEDTABLE5",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"SPANISHICON",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"ENGLISHICON",grid:0};
   GXValidFnc[30]={ id: 30, fld:"",grid:0};
   GXValidFnc[31]={ id: 31, fld:"TABLETITLECELL",grid:0};
   GXValidFnc[32]={ id: 32, fld:"TABLETITLE",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id: 35, fld:"TEXTBLOCKTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"SUBTITLE", format:1,grid:0, ctrltype: "textblock"};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"TABLECONTENT",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"FOOTERCELL",grid:0};
   GXValidFnc[47]={ id: 47, fld:"FOOTER",grid:0};
   GXValidFnc[48]={ id: 48, fld:"",grid:0};
   GXValidFnc[49]={ id: 49, fld:"UNNAMEDTABLE1",grid:0};
   GXValidFnc[50]={ id: 50, fld:"",grid:0};
   GXValidFnc[51]={ id: 51, fld:"",grid:0};
   GXValidFnc[52]={ id: 52, fld:"MOREINFOCONTACT",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"UNNAMEDTABLE2",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id: 56, fld:"",grid:0};
   GXValidFnc[57]={ id: 57, fld:"CONTACTTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id: 60, fld:"ADDRESS1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"",grid:0};
   GXValidFnc[63]={ id: 63, fld:"TELEPHONE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[64]={ id: 64, fld:"",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id: 66, fld:"EMAIL", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[67]={ id: 67, fld:"",grid:0};
   GXValidFnc[68]={ id: 68, fld:"UNNAMEDTABLE3",grid:0};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"FOLLOWUSTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[72]={ id: 72, fld:"",grid:0};
   GXValidFnc[73]={ id: 73, fld:"",grid:0};
   GXValidFnc[74]={ id: 74, fld:"UNNAMEDTABLE4",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id: 76, fld:"UAFACEBOOK", format:1,grid:0,evt:"e110n1_client", ctrltype: "textblock"};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"UAINSTAGRAM", format:1,grid:0,evt:"e120n1_client", ctrltype: "textblock"};
   GXValidFnc[79]={ id: 79, fld:"",grid:0};
   GXValidFnc[80]={ id: 80, fld:"UATWITTER", format:1,grid:0,evt:"e130n1_client", ctrltype: "textblock"};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id: 82, fld:"",grid:0};
   GXValidFnc[84]={ id: 84, fld:"",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id: 88, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[93]={ id: 93, fld:"",grid:0};
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};
   GXValidFnc[96]={ id:96 ,lvl:0,type:"date",len:8,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Pickerdummyvariable,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPICKERDUMMYVARIABLE_MPAGE",gxz:"ZV22PickerDummyVariable",gxold:"OV22PickerDummyVariable",gxvar:"AV22PickerDummyVariable",dp:{f:0,st:false,wn:false,mf:false,pic:"99/99/99",dec:0},ucs:[],op:[96],ip:[96],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV22PickerDummyVariable=gx.fn.toDatetimeValue(Value)},v2z:function(Value){if(Value!==undefined)gx.O.ZV22PickerDummyVariable=gx.fn.toDatetimeValue(Value)},v2c:function(){gx.fn.setControlValue("vPICKERDUMMYVARIABLE_MPAGE",gx.O.AV22PickerDummyVariable,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV22PickerDummyVariable=gx.fn.toDatetimeValue(this.val())},val:function(){return gx.fn.getControlValue("vPICKERDUMMYVARIABLE_MPAGE")},nac:gx.falseFn};
   this.AV15DVelop_Menu = [ ] ;
   this.AV22PickerDummyVariable = gx.date.nullDate() ;
   this.AV17Breadcrumb = "" ;
   this.Events = {"e170n2_client": ["ENTER_MPAGE", true] ,"e180n2_client": ["CANCEL_MPAGE", true] ,"e110n1_client": ["DOUAFACEBOOK_MPAGE", false] ,"e120n1_client": ["DOUAINSTAGRAM_MPAGE", false] ,"e130n1_client": ["DOUATWITTER_MPAGE", false]};
   this.EvtParms["REFRESH_MPAGE"] = [[{ctrl:'FORM_MPAGE',prop:'Caption'},{av:'AV15DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:''},{av:'AV17Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true}],[{av:'gx.fn.getCtrlProperty("TEXTBLOCKTITLE_MPAGE","Caption")',ctrl:'TEXTBLOCKTITLE_MPAGE',prop:'Caption'},{av:'AV17Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true},{av:'gx.fn.getCtrlProperty("SUBTITLE_MPAGE","Caption")',ctrl:'SUBTITLE_MPAGE',prop:'Caption'},{av:'gx.fn.getCtrlProperty("TABLEHEADERCELL_MPAGE","Class")',ctrl:'TABLEHEADERCELL_MPAGE',prop:'Class'},{av:'gx.fn.getCtrlProperty("TOPRIGHTFIXEDELEMENTS_MPAGE","Class")',ctrl:'TOPRIGHTFIXEDELEMENTS_MPAGE',prop:'Class'},{av:'gx.fn.getCtrlProperty("TABLETITLECELL_MPAGE","Visible")',ctrl:'TABLETITLECELL_MPAGE',prop:'Visible'},{av:'gx.fn.getCtrlProperty("FOOTERCELL_MPAGE","Visible")',ctrl:'FOOTERCELL_MPAGE',prop:'Visible'}]];
   this.EvtParms["START_MPAGE"] = [[],[{ctrl:'FORM_MPAGE',prop:'Headerrawhtml'},{av:'gx.fn.getCtrlProperty("LAYOUTMAINTABLE_MPAGE","Class")',ctrl:'LAYOUTMAINTABLE_MPAGE',prop:'Class'},{av:'AV15DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:''}]];
   this.EvtParms["DOUAFACEBOOK_MPAGE"] = [[],[]];
   this.EvtParms["DOUAINSTAGRAM_MPAGE"] = [[],[]];
   this.EvtParms["DOUATWITTER_MPAGE"] = [[],[]];
   this.EvtParms["VALIDV_PICKERDUMMYVARIABLE"] = [[],[]];
   this.setVCMap("AV15DVelop_Menu", "vDVELOP_MENU_MPAGE", 0, "CollWWPBaseObjects\DVelop_Menu.Item", 0, 0);
   this.setVCMap("AV17Breadcrumb", "vBREADCRUMB_MPAGE", 0, "svchar", 1000, 0);
   this.Initialize( );
});
gx.wi( function() { gx.createMasterPage(wwpbaseobjects.workwithplusmasterpage);});
