gx.evt.autoSkip=!1;gx.define("nosotros",!1,function(){var t,i,n;this.ServerClass="nosotros";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV5HomeModulesSDT=gx.fn.getControlValue("vHOMEMODULESSDT")};this.e140p3_client=function(){return this.clearMessages(),gx.text.compare("",this.AV6OptionLink)==0||this.callUrl(this.AV6OptionLink),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150p2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160p2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,38,39];this.GXLastCtrlId=39;this.BannerContainer=new gx.grid.grid(this,2,"WbpLvl2",12,"Banner","Banner","BannerContainer",this.CmpContext,this.IsMasterPage,"nosotros",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!1,!1,!1,gx.uc.HorizontalGrid,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);i=this.BannerContainer;i.startDiv(13,"Unnamedtablefsbanner","0px","0px");i.startDiv(14,"","0px","0px");i.startDiv(15,"","0px","0px");i.startDiv(16,"","0px","0px");i.addLabel();i.addBitmap("&Imagebanner","vIMAGEBANNER",17,0,"",0,"",null,"","","AttributeBannerModules ObjectFitCover","");i.endDiv();i.endDiv();i.endDiv();i.endDiv();this.BannerContainer.emptyText="";i.setRenderProp("Class","Class","FreeStyleGrid","str");i.setRenderProp("Enabled","Enabled",!0,"boolean");i.setRenderProp("Paged","Paged",!0,"bool");i.setRenderProp("ShowPageController","Showpagecontroller",!0,"bool");i.setRenderProp("PageControllerClass","Pagecontrollerclass","GridPageController","str");i.setRenderDynProp("ShowArrows","Showarrows",!0,"bool");i.setRenderProp("Infinite","Infinite",!1,"bool");i.setRenderDynProp("AutoPlay","Autoplay",!1,"bool");i.setRenderProp("AutoPlaySpeed","Autoplayspeed",3e3,"num");i.setRenderProp("VariableWidth","Variablewidth",!1,"bool");i.setRenderProp("MultiRowsExtraSmall","Multi_rows_xs",1,"num");i.setRenderProp("MultiRowsSmall","Multi_rows_sm",1,"num");i.setRenderProp("MultiRowsMedium","Multi_rows_md",1,"num");i.setRenderProp("MultiRowsLarge","Multi_rows_lg",1,"num");i.setRenderProp("CurrentPage","Currentpage","","int");i.setRenderProp("Visible","Visible",!0,"boolean");this.setGrid(i);this.GridhomemodulessdtsContainer=new gx.grid.grid(this,3,"WbpLvl3",20,"Gridhomemodulessdts","Gridhomemodulessdts","GridhomemodulessdtsContainer",this.CmpContext,this.IsMasterPage,"nosotros",[],!0,1,!1,!0,0,!1,!1,!1,"CollWWPBaseObjectsHomeModulesSDT.HomeModulesSDTItem",0,"px",0,"px","Nueva fila",!1,!1,!1,gx.grid.flexGrid,null,!1,"AV5HomeModulesSDT",!0,[2,3,3,3],!1,0,!1,!1);n=this.GridhomemodulessdtsContainer;n.startDiv(21,"Unnamedtablefsgridhomemodulessdts","0px","0px");n.startDiv(22,"","0px","0px");n.startDiv(23,"","0px","0px");n.addTextBlock("OPTIONICON",null,24);n.endDiv();n.endDiv();n.startDiv(25,"","0px","0px");n.startDiv(26,"","0px","0px");n.startDiv(27,"","0px","0px");n.addLabel();n.addSingleLineEdit("GXV2",28,"HOMEMODULESSDT__OPTIONTITLE","","","OptionTitle","svchar",80,"chr",100,80,"left",null,[],"GXV2","GXV2",!0,0,!1,!1,"AttributeHomeModulesBigTitle",1,"");n.endDiv();n.endDiv();n.endDiv();n.startDiv(29,"","0px","0px");n.startDiv(30,"","0px","0px");n.startDiv(31,"","0px","0px");n.addLabel();n.addSingleLineEdit("GXV3",32,"HOMEMODULESSDT__OPTIONDESCRIPTION","","","OptionDescription","svchar",80,"chr",100,80,"left",null,[],"GXV3","GXV3",!0,0,!1,!1,"AttributeHomeModulesBigDescription",1,"");n.endDiv();n.endDiv();n.endDiv();n.startDiv(33,"","0px","0px");n.startDiv(34,"","0px","0px");n.startTable("Unnamedtablecontentfsgridhomemodulessdts",35,"0px");n.startRow("","","","","","");n.startCell("","","","","","","","","","");n.startDiv(38,"","0px","0px");n.addLabel();n.addMultipleLineEdit("Optionlink",39,"vOPTIONLINK","","OptionLink","svchar",80,"chr",3,"row","200",200,"left",null,!0,!1,0,"");n.endDiv();n.endCell();n.endRow();n.endTable();n.endDiv();n.endDiv();n.endDiv();this.GridhomemodulessdtsContainer.emptyText="";n.setRenderProp("Class","Class","FreeStyleHomeModulesBig","str");n.setRenderProp("Enabled","Enabled",!0,"boolean");n.setRenderProp("FlexDirection","Flexdirection","row","str");n.setRenderProp("FlexWrap","Flexwrap","wrap","str");n.setRenderProp("JustifyContent","Justifycontent","center","str");n.setRenderProp("AlignItems","Alignitems","stretch","str");n.setRenderProp("AlignContent","Aligncontent","stretch","str");n.setRenderProp("Visible","Visible",!0,"boolean");this.setGrid(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLEMAIN",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TABLECONTENT",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[13]={id:13,fld:"UNNAMEDTABLEFSBANNER",grid:12};t[14]={id:14,fld:"",grid:12};t[15]={id:15,fld:"",grid:12};t[16]={id:16,fld:"",grid:12};t[17]={id:17,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.BannerContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGEBANNER",gxz:"ZV7ImageBanner",gxold:"OV7ImageBanner",gxvar:"AV7ImageBanner",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV7ImageBanner=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7ImageBanner=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vIMAGEBANNER",n||gx.fn.currentGridRowImpl(12),gx.O.AV7ImageBanner,gx.O.AV13Imagebanner_GXI)},c2v:function(n){gx.O.AV13Imagebanner_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV7ImageBanner=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vIMAGEBANNER",n||gx.fn.currentGridRowImpl(12))},val_GXI:function(n){return gx.fn.getGridControlValue("vIMAGEBANNER_GXI",n||gx.fn.currentGridRowImpl(12))},gxvar_GXI:"AV13Imagebanner_GXI",nac:gx.falseFn};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,fld:"UNNAMEDTABLEFSGRIDHOMEMODULESSDTS",grid:20,evt:"e140p3_client"};t[22]={id:22,fld:"",grid:20};t[23]={id:23,fld:"",grid:20};t[24]={id:24,fld:"OPTIONICON",format:2,grid:20,ctrltype:"textblock"};t[25]={id:25,fld:"",grid:20};t[26]={id:26,fld:"",grid:20};t[27]={id:27,fld:"",grid:20};t[28]={id:28,lvl:3,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridhomemodulessdtsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HOMEMODULESSDT__OPTIONTITLE",gxz:"ZV11GXV2",gxold:"OV11GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV2=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11GXV2=n)},v2c:function(n){gx.fn.setGridControlValue("HOMEMODULESSDT__OPTIONTITLE",n||gx.fn.currentGridRowImpl(20),gx.O.GXV2,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV2=this.val(n))},val:function(n){return gx.fn.getGridControlValue("HOMEMODULESSDT__OPTIONTITLE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[29]={id:29,fld:"",grid:20};t[30]={id:30,fld:"",grid:20};t[31]={id:31,fld:"",grid:20};t[32]={id:32,lvl:3,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridhomemodulessdtsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HOMEMODULESSDT__OPTIONDESCRIPTION",gxz:"ZV12GXV3",gxold:"OV12GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.GXV3=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12GXV3=n)},v2c:function(n){gx.fn.setGridControlValue("HOMEMODULESSDT__OPTIONDESCRIPTION",n||gx.fn.currentGridRowImpl(20),gx.O.GXV3,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.GXV3=this.val(n))},val:function(n){return gx.fn.getGridControlValue("HOMEMODULESSDT__OPTIONDESCRIPTION",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[33]={id:33,fld:"",grid:20};t[34]={id:34,fld:"",grid:20};t[35]={id:35,fld:"UNNAMEDTABLECONTENTFSGRIDHOMEMODULESSDTS",grid:20};t[38]={id:38,fld:"",grid:20};t[39]={id:39,lvl:3,type:"svchar",len:200,dec:0,sign:!1,ro:1,isacc:0,multiline:!0,grid:20,gxgrid:this.GridhomemodulessdtsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vOPTIONLINK",gxz:"ZV6OptionLink",gxold:"OV6OptionLink",gxvar:"AV6OptionLink",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV6OptionLink=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6OptionLink=n)},v2c:function(n){gx.fn.setGridControlValue("vOPTIONLINK",n||gx.fn.currentGridRowImpl(20),gx.O.AV6OptionLink,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV6OptionLink=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vOPTIONLINK",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};this.ZV7ImageBanner="";this.OV7ImageBanner="";this.ZV11GXV2="";this.OV11GXV2="";this.ZV12GXV3="";this.OV12GXV3="";this.ZV6OptionLink="";this.OV6OptionLink="";this.AV7ImageBanner="";this.GXV2="";this.GXV3="";this.AV6OptionLink="";this.AV5HomeModulesSDT=[];this.Events={e150p2_client:["ENTER",!0],e160p2_client:["CANCEL",!0],e140p3_client:["UNNAMEDTABLEFSGRIDHOMEMODULESSDTS.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"BANNER_nFirstRecordOnPage"},{av:"BANNER_nEOF"},{av:"GRIDHOMEMODULESSDTS_nFirstRecordOnPage"},{av:"GRIDHOMEMODULESSDTS_nEOF"},{av:'gx.fn.getCtrlProperty("vOPTIONLINK","Visible")',ctrl:"vOPTIONLINK",prop:"Visible"},{av:"AV5HomeModulesSDT",fld:"vHOMEMODULESSDT",grid:20,pic:"",hsh:!0},{av:"nRC_GXsfl_20",ctrl:"GRIDHOMEMODULESSDTS",prop:"GridRC"}],[]];this.EvtParms.START=[[],[{ctrl:"BANNER",prop:"Showarrows"},{ctrl:"BANNER",prop:"Autoplay"},{av:'gx.fn.getCtrlProperty("vOPTIONLINK","Visible")',ctrl:"vOPTIONLINK",prop:"Visible"}]];this.EvtParms["BANNER.LOAD"]=[[],[{av:"AV7ImageBanner",fld:"vIMAGEBANNER",pic:""}]];this.EvtParms["GRIDHOMEMODULESSDTS.LOAD"]=[[{av:"AV5HomeModulesSDT",fld:"vHOMEMODULESSDT",grid:20,pic:"",hsh:!0},{av:"GRIDHOMEMODULESSDTS_nFirstRecordOnPage"},{av:"nRC_GXsfl_20",ctrl:"GRIDHOMEMODULESSDTS",prop:"GridRC"}],[{av:'gx.fn.getCtrlProperty("OPTIONICON","Caption")',ctrl:"OPTIONICON",prop:"Caption"},{av:"AV6OptionLink",fld:"vOPTIONLINK",pic:""}]];this.EvtParms["UNNAMEDTABLEFSGRIDHOMEMODULESSDTS.CLICK"]=[[{av:"AV6OptionLink",fld:"vOPTIONLINK",pic:""}],[]];this.setVCMap("AV5HomeModulesSDT","vHOMEMODULESSDT",0,"CollWWPBaseObjectsHomeModulesSDT.HomeModulesSDTItem",0,0);i.addRefreshingVar({rfrVar:"AV5HomeModulesSDT"});i.addRefreshingParm({rfrVar:"AV5HomeModulesSDT"});n.addRefreshingVar({rfrVar:"AV6OptionLink",rfrProp:"Visible",gxAttId:"Optionlink"});n.addRefreshingVar({rfrVar:"AV5HomeModulesSDT"});n.addRefreshingParm({rfrVar:"AV6OptionLink",rfrProp:"Visible",gxAttId:"Optionlink"});n.addRefreshingParm({rfrVar:"AV5HomeModulesSDT"});this.addGridBCProperty("Homemodulessdt",["OptionTitle"],this.GXValidFnc[28],"AV5HomeModulesSDT");this.addGridBCProperty("Homemodulessdt",["OptionDescription"],this.GXValidFnc[32],"AV5HomeModulesSDT");this.Initialize()});gx.wi(function(){gx.createParentObj(nosotros)})