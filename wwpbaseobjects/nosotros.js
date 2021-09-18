gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.nosotros', false, function () {
   this.ServerClass =  "wwpbaseobjects.nosotros" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e130q2_client=function()
   {
      return this.executeServerEvent("ENTER", true, arguments[0], false, false);
   };
   this.e140q2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, arguments[0], false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,33,34,36,37,38,39,40,41,42,43,44,45,46,49,50,52,53,54,55,56,57,58,59,60,61,62,65,66,68,69,70,71,72,73,74,75,76,77,78,81,82,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,117,118,119,120,121,122,123,124,125,126,127,128,129,130,131,132];
   this.GXLastCtrlId =132;
   this.FstestimonialsContainer = new gx.grid.grid(this, 2,"WbpLvl2",116,"Fstestimonials","Fstestimonials","FstestimonialsContainer",this.CmpContext,this.IsMasterPage,"wwpbaseobjects.nosotros",[],true,3,false,true,0,false,false,false,"CollWWPBaseObjects\SDTHomeTestimonials.SDTHomeTestimonialsItem",0,"px",0,"px","Nueva fila",false,false,false,gx.uc.HorizontalGrid,null,false,"AV6SDTHomeTestimonials",true,[1,3,3,3],false,0,false,false);
   var FstestimonialsContainer = this.FstestimonialsContainer;
   FstestimonialsContainer.startDiv(117,"Unnamedtablefsfstestimonials","0px","0px");
   FstestimonialsContainer.startDiv(118,"","0px","0px");
   FstestimonialsContainer.startDiv(119,"","0px","0px");
   FstestimonialsContainer.startDiv(120,"","0px","0px");
   FstestimonialsContainer.addLabel();
   FstestimonialsContainer.addMultipleLineEdit("GXV2",121,"SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION","","SDTHomeTestimonialsDescription","svchar",80,"chr",5,"row","400",400,"left",null,true,false,0,"");
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.startDiv(122,"","0px","0px");
   FstestimonialsContainer.startDiv(123,"","0px","0px");
   FstestimonialsContainer.startDiv(124,"Unnamedtable3","0px","0px");
   FstestimonialsContainer.startDiv(125,"","0px","0px");
   FstestimonialsContainer.startDiv(126,"","0px","0px");
   FstestimonialsContainer.startDiv(127,"","0px","0px");
   FstestimonialsContainer.addLabel();
   FstestimonialsContainer.addSingleLineEdit("GXV3",128,"SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME","","","SDTHomeTestimonialsName","svchar",40,"chr",40,40,"left",null,[],"GXV3","GXV3",true,0,false,false,"AttributeLandingPurusTestimonialTitle",1,"");
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.startDiv(129,"","0px","0px");
   FstestimonialsContainer.startDiv(130,"","0px","0px");
   FstestimonialsContainer.startDiv(131,"","0px","0px");
   FstestimonialsContainer.addLabel();
   FstestimonialsContainer.addSingleLineEdit("GXV4",132,"SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY","","","SDTHomeTestimonialsCompany","svchar",40,"chr",40,40,"left",null,[],"GXV4","GXV4",true,0,false,false,"AttributeLandingPurusTestimonialSubtitle",1,"");
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   FstestimonialsContainer.endDiv();
   this.FstestimonialsContainer.emptyText = "";
   FstestimonialsContainer.setRenderProp("Class", "Class", "FreeStyleGrid", "str");
   FstestimonialsContainer.setRenderProp("Enabled", "Enabled", true, "boolean");
   FstestimonialsContainer.setRenderProp("Paged", "Paged", true, "bool");
   FstestimonialsContainer.setRenderProp("ShowPageController", "Showpagecontroller", true, "bool");
   FstestimonialsContainer.setRenderProp("PageControllerClass", "Pagecontrollerclass", "GridPageController", "str");
   FstestimonialsContainer.setRenderProp("ShowArrows", "Showarrows", true, "bool");
   FstestimonialsContainer.setRenderProp("Infinite", "Infinite", false, "bool");
   FstestimonialsContainer.setRenderProp("AutoPlay", "Autoplay", false, "bool");
   FstestimonialsContainer.setRenderProp("AutoPlaySpeed", "Autoplayspeed", 3000, "num");
   FstestimonialsContainer.setRenderProp("VariableWidth", "Variablewidth", false, "bool");
   FstestimonialsContainer.setRenderProp("MultiRowsExtraSmall", "Multi_rows_xs", 1, "num");
   FstestimonialsContainer.setRenderProp("MultiRowsSmall", "Multi_rows_sm", 1, "num");
   FstestimonialsContainer.setRenderProp("MultiRowsMedium", "Multi_rows_md", 1, "num");
   FstestimonialsContainer.setRenderProp("MultiRowsLarge", "Multi_rows_lg", 1, "num");
   FstestimonialsContainer.setRenderProp("CurrentPage", "Currentpage", '', "int");
   FstestimonialsContainer.setRenderProp("Visible", "Visible", true, "boolean");
   this.setGrid(FstestimonialsContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[9]={ id: 9, fld:"HEADERSECTION",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"CUSTOMERSTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"MAINNUMBERSTITLECC", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"SDF", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"SDFA", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"SDFH", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id: 26, fld:"",grid:0};
   GXValidFnc[27]={ id: 27, fld:"UNNAMEDTABLE1",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id: 30, fld:"TABLETOPINFO",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id:34 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGE",gxz:"ZV12Image",gxold:"OV12Image",gxvar:"AV12Image",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV12Image=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV12Image=Value},v2c:function(){gx.fn.setMultimediaValue("vIMAGE",gx.O.AV12Image,gx.O.AV30Image_GXI)},c2v:function(){gx.O.AV30Image_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV12Image=this.val()},val:function(){return gx.fn.getBlobValue("vIMAGE")},val_GXI:function(){return gx.fn.getControlValue("vIMAGE_GXI")}, gxvar_GXI:'AV30Image_GXI',nac:gx.falseFn};
   GXValidFnc[36]={ id: 36, fld:"TABLETITLE",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id: 39, fld:"",grid:0};
   GXValidFnc[40]={ id:40 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTITLE",gxz:"ZV13Title",gxold:"OV13Title",gxvar:"AV13Title",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV13Title=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV13Title=Value},v2c:function(){gx.fn.setControlValue("vTITLE",gx.O.AV13Title,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV13Title=this.val()},val:function(){return gx.fn.getControlValue("vTITLE")},nac:gx.falseFn};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"",grid:0};
   GXValidFnc[43]={ id: 43, fld:"",grid:0};
   GXValidFnc[44]={ id:44 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBTITLE",gxz:"ZV14Subtitle",gxold:"OV14Subtitle",gxvar:"AV14Subtitle",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV14Subtitle=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV14Subtitle=Value},v2c:function(){gx.fn.setControlValue("vSUBTITLE",gx.O.AV14Subtitle,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV14Subtitle=this.val()},val:function(){return gx.fn.getControlValue("vSUBTITLE")},nac:gx.falseFn};
   GXValidFnc[45]={ id: 45, fld:"",grid:0};
   GXValidFnc[46]={ id: 46, fld:"TABLETOPINFO2",grid:0};
   GXValidFnc[49]={ id: 49, fld:"",grid:0};
   GXValidFnc[50]={ id:50 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGE2",gxz:"ZV15Image2",gxold:"OV15Image2",gxvar:"AV15Image2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV15Image2=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV15Image2=Value},v2c:function(){gx.fn.setMultimediaValue("vIMAGE2",gx.O.AV15Image2,gx.O.AV31Image2_GXI)},c2v:function(){gx.O.AV31Image2_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV15Image2=this.val()},val:function(){return gx.fn.getBlobValue("vIMAGE2")},val_GXI:function(){return gx.fn.getControlValue("vIMAGE2_GXI")}, gxvar_GXI:'AV31Image2_GXI',nac:gx.falseFn};
   GXValidFnc[52]={ id: 52, fld:"TABLETITLE2",grid:0};
   GXValidFnc[53]={ id: 53, fld:"",grid:0};
   GXValidFnc[54]={ id: 54, fld:"",grid:0};
   GXValidFnc[55]={ id: 55, fld:"",grid:0};
   GXValidFnc[56]={ id:56 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTITLE2",gxz:"ZV16Title2",gxold:"OV16Title2",gxvar:"AV16Title2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV16Title2=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV16Title2=Value},v2c:function(){gx.fn.setControlValue("vTITLE2",gx.O.AV16Title2,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV16Title2=this.val()},val:function(){return gx.fn.getControlValue("vTITLE2")},nac:gx.falseFn};
   GXValidFnc[57]={ id: 57, fld:"",grid:0};
   GXValidFnc[58]={ id: 58, fld:"",grid:0};
   GXValidFnc[59]={ id: 59, fld:"",grid:0};
   GXValidFnc[60]={ id:60 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBTITLE2",gxz:"ZV17Subtitle2",gxold:"OV17Subtitle2",gxvar:"AV17Subtitle2",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV17Subtitle2=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV17Subtitle2=Value},v2c:function(){gx.fn.setControlValue("vSUBTITLE2",gx.O.AV17Subtitle2,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV17Subtitle2=this.val()},val:function(){return gx.fn.getControlValue("vSUBTITLE2")},nac:gx.falseFn};
   GXValidFnc[61]={ id: 61, fld:"",grid:0};
   GXValidFnc[62]={ id: 62, fld:"TABLETOPINFO3",grid:0};
   GXValidFnc[65]={ id: 65, fld:"",grid:0};
   GXValidFnc[66]={ id:66 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGE3",gxz:"ZV18Image3",gxold:"OV18Image3",gxvar:"AV18Image3",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV18Image3=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV18Image3=Value},v2c:function(){gx.fn.setMultimediaValue("vIMAGE3",gx.O.AV18Image3,gx.O.AV32Image3_GXI)},c2v:function(){gx.O.AV32Image3_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV18Image3=this.val()},val:function(){return gx.fn.getBlobValue("vIMAGE3")},val_GXI:function(){return gx.fn.getControlValue("vIMAGE3_GXI")}, gxvar_GXI:'AV32Image3_GXI',nac:gx.falseFn};
   GXValidFnc[68]={ id: 68, fld:"TABLETITLE3",grid:0};
   GXValidFnc[69]={ id: 69, fld:"",grid:0};
   GXValidFnc[70]={ id: 70, fld:"",grid:0};
   GXValidFnc[71]={ id: 71, fld:"",grid:0};
   GXValidFnc[72]={ id:72 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTITLE3",gxz:"ZV19Title3",gxold:"OV19Title3",gxvar:"AV19Title3",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV19Title3=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV19Title3=Value},v2c:function(){gx.fn.setControlValue("vTITLE3",gx.O.AV19Title3,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV19Title3=this.val()},val:function(){return gx.fn.getControlValue("vTITLE3")},nac:gx.falseFn};
   GXValidFnc[73]={ id: 73, fld:"",grid:0};
   GXValidFnc[74]={ id: 74, fld:"",grid:0};
   GXValidFnc[75]={ id: 75, fld:"",grid:0};
   GXValidFnc[76]={ id:76 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBTITLE3",gxz:"ZV20Subtitle3",gxold:"OV20Subtitle3",gxvar:"AV20Subtitle3",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV20Subtitle3=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV20Subtitle3=Value},v2c:function(){gx.fn.setControlValue("vSUBTITLE3",gx.O.AV20Subtitle3,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV20Subtitle3=this.val()},val:function(){return gx.fn.getControlValue("vSUBTITLE3")},nac:gx.falseFn};
   GXValidFnc[77]={ id: 77, fld:"",grid:0};
   GXValidFnc[78]={ id: 78, fld:"TABLETOPINFO4",grid:0};
   GXValidFnc[81]={ id: 81, fld:"",grid:0};
   GXValidFnc[82]={ id:82 ,lvl:0,type:"bits",len:1024,dec:0,sign:false,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIMAGE4",gxz:"ZV21Image4",gxold:"OV21Image4",gxvar:"AV21Image4",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV21Image4=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV21Image4=Value},v2c:function(){gx.fn.setMultimediaValue("vIMAGE4",gx.O.AV21Image4,gx.O.AV33Image4_GXI)},c2v:function(){gx.O.AV33Image4_GXI=this.val_GXI();if(this.val()!==undefined)gx.O.AV21Image4=this.val()},val:function(){return gx.fn.getBlobValue("vIMAGE4")},val_GXI:function(){return gx.fn.getControlValue("vIMAGE4_GXI")}, gxvar_GXI:'AV33Image4_GXI',nac:gx.falseFn};
   GXValidFnc[84]={ id: 84, fld:"TABLETITLE4",grid:0};
   GXValidFnc[85]={ id: 85, fld:"",grid:0};
   GXValidFnc[86]={ id: 86, fld:"",grid:0};
   GXValidFnc[87]={ id: 87, fld:"",grid:0};
   GXValidFnc[88]={ id:88 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTITLE4",gxz:"ZV22Title4",gxold:"OV22Title4",gxvar:"AV22Title4",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV22Title4=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV22Title4=Value},v2c:function(){gx.fn.setControlValue("vTITLE4",gx.O.AV22Title4,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV22Title4=this.val()},val:function(){return gx.fn.getControlValue("vTITLE4")},nac:gx.falseFn};
   GXValidFnc[89]={ id: 89, fld:"",grid:0};
   GXValidFnc[90]={ id: 90, fld:"",grid:0};
   GXValidFnc[91]={ id: 91, fld:"",grid:0};
   GXValidFnc[92]={ id:92 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBTITLE4",gxz:"ZV23Subtitle4",gxold:"OV23Subtitle4",gxvar:"AV23Subtitle4",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV23Subtitle4=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV23Subtitle4=Value},v2c:function(){gx.fn.setControlValue("vSUBTITLE4",gx.O.AV23Subtitle4,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV23Subtitle4=this.val()},val:function(){return gx.fn.getControlValue("vSUBTITLE4")},nac:gx.falseFn};
   GXValidFnc[93]={ id: 93, fld:"",grid:0};
   GXValidFnc[94]={ id: 94, fld:"",grid:0};
   GXValidFnc[95]={ id: 95, fld:"UNNAMEDTABLE2",grid:0};
   GXValidFnc[96]={ id: 96, fld:"",grid:0};
   GXValidFnc[97]={ id: 97, fld:"",grid:0};
   GXValidFnc[98]={ id: 98, fld:"UNNAMEDTABLE4",grid:0};
   GXValidFnc[99]={ id: 99, fld:"",grid:0};
   GXValidFnc[100]={ id: 100, fld:"",grid:0};
   GXValidFnc[101]={ id: 101, fld:"ASD", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[102]={ id: 102, fld:"",grid:0};
   GXValidFnc[103]={ id: 103, fld:"",grid:0};
   GXValidFnc[104]={ id: 104, fld:"ASDS", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[105]={ id: 105, fld:"",grid:0};
   GXValidFnc[106]={ id: 106, fld:"",grid:0};
   GXValidFnc[107]={ id: 107, fld:"ASDGG", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[108]={ id: 108, fld:"",grid:0};
   GXValidFnc[109]={ id: 109, fld:"",grid:0};
   GXValidFnc[110]={ id: 110, fld:"TESTIMONIALSSECTION",grid:0};
   GXValidFnc[111]={ id: 111, fld:"",grid:0};
   GXValidFnc[112]={ id: 112, fld:"",grid:0};
   GXValidFnc[113]={ id: 113, fld:"TESTIMONIALSTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[114]={ id: 114, fld:"",grid:0};
   GXValidFnc[115]={ id: 115, fld:"",grid:0};
   GXValidFnc[117]={ id: 117, fld:"UNNAMEDTABLEFSFSTESTIMONIALS",grid:116};
   GXValidFnc[118]={ id: 118, fld:"",grid:116};
   GXValidFnc[119]={ id: 119, fld:"",grid:116};
   GXValidFnc[120]={ id: 120, fld:"",grid:116};
   GXValidFnc[121]={ id:121 ,lvl:2,type:"svchar",len:400,dec:0,sign:false,ro:1,isacc:0, multiline:true,grid:116,gxgrid:this.FstestimonialsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION",gxz:"ZV27GXV2",gxold:"OV27GXV2",gxvar:"GXV2",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.GXV2=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV27GXV2=Value},v2c:function(row){gx.fn.setGridControlValue("SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION",row || gx.fn.currentGridRowImpl(116),gx.O.GXV2,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.GXV2=this.val(row)},val:function(row){return gx.fn.getGridControlValue("SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION",row || gx.fn.currentGridRowImpl(116))},nac:gx.falseFn};
   GXValidFnc[122]={ id: 122, fld:"",grid:116};
   GXValidFnc[123]={ id: 123, fld:"",grid:116};
   GXValidFnc[124]={ id: 124, fld:"UNNAMEDTABLE3",grid:116};
   GXValidFnc[125]={ id: 125, fld:"",grid:116};
   GXValidFnc[126]={ id: 126, fld:"",grid:116};
   GXValidFnc[127]={ id: 127, fld:"",grid:116};
   GXValidFnc[128]={ id:128 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,ro:1,isacc:0,grid:116,gxgrid:this.FstestimonialsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME",gxz:"ZV28GXV3",gxold:"OV28GXV3",gxvar:"GXV3",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.GXV3=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV28GXV3=Value},v2c:function(row){gx.fn.setGridControlValue("SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME",row || gx.fn.currentGridRowImpl(116),gx.O.GXV3,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.GXV3=this.val(row)},val:function(row){return gx.fn.getGridControlValue("SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME",row || gx.fn.currentGridRowImpl(116))},nac:gx.falseFn};
   GXValidFnc[129]={ id: 129, fld:"",grid:116};
   GXValidFnc[130]={ id: 130, fld:"",grid:116};
   GXValidFnc[131]={ id: 131, fld:"",grid:116};
   GXValidFnc[132]={ id:132 ,lvl:2,type:"svchar",len:40,dec:0,sign:false,ro:1,isacc:0,grid:116,gxgrid:this.FstestimonialsContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY",gxz:"ZV29GXV4",gxold:"OV29GXV4",gxvar:"GXV4",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:'text',autoCorrect:"1",v2v:function(Value){if(Value!==undefined)gx.O.GXV4=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV29GXV4=Value},v2c:function(row){gx.fn.setGridControlValue("SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY",row || gx.fn.currentGridRowImpl(116),gx.O.GXV4,0)},c2v:function(row){if(this.val(row)!==undefined)gx.O.GXV4=this.val(row)},val:function(row){return gx.fn.getGridControlValue("SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY",row || gx.fn.currentGridRowImpl(116))},nac:gx.falseFn};
   this.AV30Image_GXI = "" ;
   this.AV12Image = "" ;
   this.ZV12Image = "" ;
   this.OV12Image = "" ;
   this.AV13Title = "" ;
   this.ZV13Title = "" ;
   this.OV13Title = "" ;
   this.AV14Subtitle = "" ;
   this.ZV14Subtitle = "" ;
   this.OV14Subtitle = "" ;
   this.AV31Image2_GXI = "" ;
   this.AV15Image2 = "" ;
   this.ZV15Image2 = "" ;
   this.OV15Image2 = "" ;
   this.AV16Title2 = "" ;
   this.ZV16Title2 = "" ;
   this.OV16Title2 = "" ;
   this.AV17Subtitle2 = "" ;
   this.ZV17Subtitle2 = "" ;
   this.OV17Subtitle2 = "" ;
   this.AV32Image3_GXI = "" ;
   this.AV18Image3 = "" ;
   this.ZV18Image3 = "" ;
   this.OV18Image3 = "" ;
   this.AV19Title3 = "" ;
   this.ZV19Title3 = "" ;
   this.OV19Title3 = "" ;
   this.AV20Subtitle3 = "" ;
   this.ZV20Subtitle3 = "" ;
   this.OV20Subtitle3 = "" ;
   this.AV33Image4_GXI = "" ;
   this.AV21Image4 = "" ;
   this.ZV21Image4 = "" ;
   this.OV21Image4 = "" ;
   this.AV22Title4 = "" ;
   this.ZV22Title4 = "" ;
   this.OV22Title4 = "" ;
   this.AV23Subtitle4 = "" ;
   this.ZV23Subtitle4 = "" ;
   this.OV23Subtitle4 = "" ;
   this.ZV27GXV2 = "" ;
   this.OV27GXV2 = "" ;
   this.ZV28GXV3 = "" ;
   this.OV28GXV3 = "" ;
   this.ZV29GXV4 = "" ;
   this.OV29GXV4 = "" ;
   this.AV12Image = "" ;
   this.AV13Title = "" ;
   this.AV14Subtitle = "" ;
   this.AV15Image2 = "" ;
   this.AV16Title2 = "" ;
   this.AV17Subtitle2 = "" ;
   this.AV18Image3 = "" ;
   this.AV19Title3 = "" ;
   this.AV20Subtitle3 = "" ;
   this.AV21Image4 = "" ;
   this.AV22Title4 = "" ;
   this.AV23Subtitle4 = "" ;
   this.GXV2 = "" ;
   this.GXV3 = "" ;
   this.GXV4 = "" ;
   this.Events = {"e130q2_client": ["ENTER", true] ,"e140q2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[{av:'FSTESTIMONIALS_nFirstRecordOnPage'},{av:'FSTESTIMONIALS_nEOF'},{av:'AV6SDTHomeTestimonials',fld:'vSDTHOMETESTIMONIALS',grid:116,pic:''},{av:'nRC_GXsfl_116',ctrl:'FSTESTIMONIALS',prop:'GridRC'}],[]];
   this.EvtParms["START"] = [[{av:'AV6SDTHomeTestimonials',fld:'vSDTHOMETESTIMONIALS',grid:116,pic:''},{av:'FSTESTIMONIALS_nFirstRecordOnPage'},{av:'nRC_GXsfl_116',ctrl:'FSTESTIMONIALS',prop:'GridRC'},{av:'FSTESTIMONIALS_nEOF'}],[{av:'AV6SDTHomeTestimonials',fld:'vSDTHOMETESTIMONIALS',grid:116,pic:''},{av:'FSTESTIMONIALS_nFirstRecordOnPage'},{av:'nRC_GXsfl_116',ctrl:'FSTESTIMONIALS',prop:'GridRC'},{av:'AV12Image',fld:'vIMAGE',pic:''},{av:'AV13Title',fld:'vTITLE',pic:''},{av:'AV14Subtitle',fld:'vSUBTITLE',pic:''},{av:'AV15Image2',fld:'vIMAGE2',pic:''},{av:'AV16Title2',fld:'vTITLE2',pic:''},{av:'AV17Subtitle2',fld:'vSUBTITLE2',pic:''},{av:'AV18Image3',fld:'vIMAGE3',pic:''},{av:'AV19Title3',fld:'vTITLE3',pic:''},{av:'AV20Subtitle3',fld:'vSUBTITLE3',pic:''},{av:'AV21Image4',fld:'vIMAGE4',pic:''},{av:'AV22Title4',fld:'vTITLE4',pic:''},{av:'AV23Subtitle4',fld:'vSUBTITLE4',pic:''}]];
   this.EvtParms["FSTESTIMONIALS.LOAD"] = [[],[]];
   this.addGridBCProperty("Sdthometestimonials", ["SDTHomeTestimonialsDescription"], this.GXValidFnc[121], "AV6SDTHomeTestimonials");
   this.addGridBCProperty("Sdthometestimonials", ["SDTHomeTestimonialsName"], this.GXValidFnc[128], "AV6SDTHomeTestimonials");
   this.addGridBCProperty("Sdthometestimonials", ["SDTHomeTestimonialsCompany"], this.GXValidFnc[132], "AV6SDTHomeTestimonials");
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.nosotros);});
