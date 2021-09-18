gx.evt.autoSkip = false;
gx.define('wwpbaseobjects.contacto', false, function () {
   this.ServerClass =  "wwpbaseobjects.contacto" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.setObjectType("web");
   this.hasEnterEvent = true;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.SetStandaloneVars=function()
   {
   };
   this.e120t2_client=function()
   {
      return this.executeServerEvent("ENTER", true, null, false, false);
   };
   this.e140t2_client=function()
   {
      return this.executeServerEvent("CANCEL", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42];
   this.GXLastCtrlId =42;
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"LAYOUTMAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLEMAIN",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"",grid:0};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"HEADERSECTION",grid:0};
   GXValidFnc[13]={ id: 13, fld:"",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"CONTACTTITLE", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[16]={ id: 16, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"TABLECONTENT",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   GXValidFnc[21]={ id: 21, fld:"CONTACTINFO", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[22]={ id: 22, fld:"",grid:0};
   GXValidFnc[23]={ id: 23, fld:"",grid:0};
   GXValidFnc[24]={ id: 24, fld:"",grid:0};
   GXValidFnc[25]={ id: 25, fld:"",grid:0};
   GXValidFnc[26]={ id:26 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",gxz:"ZV5Name",gxold:"OV5Name",gxvar:"AV5Name",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV5Name=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV5Name=Value},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV5Name,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV5Name=this.val()},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};
   GXValidFnc[27]={ id: 27, fld:"",grid:0};
   GXValidFnc[28]={ id: 28, fld:"",grid:0};
   GXValidFnc[29]={ id: 29, fld:"",grid:0};
   GXValidFnc[30]={ id:30 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",gxz:"ZV6Email",gxold:"OV6Email",gxvar:"AV6Email",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV6Email=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV6Email=Value},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV6Email,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV6Email=this.val()},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};
   GXValidFnc[31]={ id: 31, fld:"",grid:0};
   GXValidFnc[32]={ id: 32, fld:"",grid:0};
   GXValidFnc[33]={ id: 33, fld:"",grid:0};
   GXValidFnc[34]={ id: 34, fld:"",grid:0};
   GXValidFnc[35]={ id:35 ,lvl:0,type:"svchar",len:100,dec:0,sign:false,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSUBJECT",gxz:"ZV7Subject",gxold:"OV7Subject",gxvar:"AV7Subject",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV7Subject=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV7Subject=Value},v2c:function(){gx.fn.setControlValue("vSUBJECT",gx.O.AV7Subject,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV7Subject=this.val()},val:function(){return gx.fn.getControlValue("vSUBJECT")},nac:gx.falseFn};
   GXValidFnc[36]={ id: 36, fld:"",grid:0};
   GXValidFnc[37]={ id: 37, fld:"",grid:0};
   GXValidFnc[38]={ id: 38, fld:"",grid:0};
   GXValidFnc[39]={ id:39 ,lvl:0,type:"svchar",len:500,dec:0,sign:false,ro:0,multiline:true,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vMESSAGE",gxz:"ZV8Message",gxold:"OV8Message",gxvar:"AV8Message",ucs:[],op:[],ip:[],
						nacdep:[],ctrltype:"edit",v2v:function(Value){if(Value!==undefined)gx.O.AV8Message=Value},v2z:function(Value){if(Value!==undefined)gx.O.ZV8Message=Value},v2c:function(){gx.fn.setControlValue("vMESSAGE",gx.O.AV8Message,0)},c2v:function(){if(this.val()!==undefined)gx.O.AV8Message=this.val()},val:function(){return gx.fn.getControlValue("vMESSAGE")},nac:gx.falseFn};
   GXValidFnc[40]={ id: 40, fld:"",grid:0};
   GXValidFnc[41]={ id: 41, fld:"",grid:0};
   GXValidFnc[42]={ id: 42, fld:"BTNENTER",grid:0,evt:"e120t2_client",std:"ENTER"};
   this.AV5Name = "" ;
   this.ZV5Name = "" ;
   this.OV5Name = "" ;
   this.AV6Email = "" ;
   this.ZV6Email = "" ;
   this.OV6Email = "" ;
   this.AV7Subject = "" ;
   this.ZV7Subject = "" ;
   this.OV7Subject = "" ;
   this.AV8Message = "" ;
   this.ZV8Message = "" ;
   this.OV8Message = "" ;
   this.AV5Name = "" ;
   this.AV6Email = "" ;
   this.AV7Subject = "" ;
   this.AV8Message = "" ;
   this.Events = {"e120t2_client": ["ENTER", true] ,"e140t2_client": ["CANCEL", true]};
   this.EvtParms["REFRESH"] = [[],[]];
   this.EvtParms["START"] = [[],[]];
   this.EvtParms["ENTER"] = [[],[]];
   this.EnterCtrl = ["BTNENTER"];
   this.Initialize( );
});
gx.wi( function() { gx.createParentObj(wwpbaseobjects.contacto);});
