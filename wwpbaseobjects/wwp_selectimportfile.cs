using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_selectimportfile : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwp_selectimportfile( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_selectimportfile( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( ref string aP0_TransactionName ,
                           ref string aP1_ImportType ,
                           ref string aP2_ExtraParmsJson )
      {
         this.AV14TransactionName = aP0_TransactionName;
         this.AV9ImportType = aP1_ImportType;
         this.AV6ExtraParmsJson = aP2_ExtraParmsJson;
         executePrivate();
         aP0_TransactionName=this.AV14TransactionName;
         aP1_ImportType=this.AV9ImportType;
         aP2_ExtraParmsJson=this.AV6ExtraParmsJson;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "TransactionName");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TransactionName");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TransactionName");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV14TransactionName = gxfirstwebparm;
               AssignAttri("", false, "AV14TransactionName", AV14TransactionName);
               GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14TransactionName, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9ImportType = GetPar( "ImportType");
                  AssignAttri("", false, "AV9ImportType", AV9ImportType);
                  GxWebStd.gx_hidden_field( context, "gxhash_vIMPORTTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ImportType, "")), context));
                  AV6ExtraParmsJson = GetPar( "ExtraParmsJson");
                  AssignAttri("", false, "AV6ExtraParmsJson", AV6ExtraParmsJson);
                  GxWebStd.gx_hidden_field( context, "gxhash_vEXTRAPARMSJSON", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ExtraParmsJson, "")), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA0K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0K2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 2155220), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 2155220), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 2155220), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202191511542085", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_selectimportfile.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14TransactionName)),UrlEncode(StringUtil.RTrim(AV9ImportType)),UrlEncode(StringUtil.RTrim(AV6ExtraParmsJson))}, new string[] {"TransactionName","ImportType","ExtraParmsJson"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vIMPORTTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ImportType, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vERRORMSGS", GetSecureSignedToken( "", AV5ErrorMsgs, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vEXTRAPARMSJSON", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ExtraParmsJson, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14TransactionName, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vIMPORTTYPE", AV9ImportType);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMPORTTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ImportType, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMSGS", AV5ErrorMsgs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMSGS", AV5ErrorMsgs);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vERRORMSGS", GetSecureSignedToken( "", AV5ErrorMsgs, context));
         GxWebStd.gx_hidden_field( context, "vEXTRAPARMSJSON", AV6ExtraParmsJson);
         GxWebStd.gx_hidden_field( context, "gxhash_vEXTRAPARMSJSON", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ExtraParmsJson, "")), context));
         GxWebStd.gx_hidden_field( context, "vTRANSACTIONNAME", AV14TransactionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14TransactionName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vRET", AV13Ret);
         GXCCtlgxBlob = "vFILTERTOUPLOAD" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, AV7FilterToUpload);
         GxWebStd.gx_hidden_field( context, "vFILTERTOUPLOAD_Filename", StringUtil.RTrim( edtavFiltertoupload_Filename));
         GxWebStd.gx_hidden_field( context, "vFILTERTOUPLOAD_Filename", StringUtil.RTrim( edtavFiltertoupload_Filename));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0K2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwpbaseobjects.wwp_selectimportfile.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14TransactionName)),UrlEncode(StringUtil.RTrim(AV9ImportType)),UrlEncode(StringUtil.RTrim(AV6ExtraParmsJson))}, new string[] {"TransactionName","ImportType","ExtraParmsJson"})  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_SelectImportFile" ;
      }

      public override string GetPgmdesc( )
      {
         return "Select file to import" ;
      }

      protected void WB0K0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransactionPopUp", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell AttributeImportFileCell DscTop", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltertoupload_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltertoupload_Internalname, "File", " AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            ClassString = "Attribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            edtavFiltertoupload_Filetype = "tmp";
            AssignProp("", false, edtavFiltertoupload_Internalname, "Filetype", edtavFiltertoupload_Filetype, true);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7FilterToUpload)) )
            {
               gxblobfileaux.Source = AV7FilterToUpload;
               if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtavFiltertoupload_Filetype, "tmp") != 0 ) )
               {
                  gxblobfileaux.SetExtension(StringUtil.Trim( edtavFiltertoupload_Filetype));
               }
               if ( gxblobfileaux.ErrCode == 0 )
               {
                  AV7FilterToUpload = gxblobfileaux.GetURI();
                  AssignProp("", false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV7FilterToUpload), true);
                  edtavFiltertoupload_Filetype = gxblobfileaux.GetExtension();
                  AssignProp("", false, edtavFiltertoupload_Internalname, "Filetype", edtavFiltertoupload_Filetype, true);
               }
               AssignProp("", false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV7FilterToUpload), true);
            }
            GxWebStd.gx_blob_field( context, edtavFiltertoupload_Internalname, StringUtil.RTrim( AV7FilterToUpload), context.PathToRelativeUrl( AV7FilterToUpload), (String.IsNullOrEmpty(StringUtil.RTrim( edtavFiltertoupload_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtavFiltertoupload_Filetype)) ? AV7FilterToUpload : edtavFiltertoupload_Filetype)) : edtavFiltertoupload_Contenttype), false, "", edtavFiltertoupload_Parameters, 0, edtavFiltertoupload_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtavFiltertoupload_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "", "", "HLP_WWPBaseObjects\\WWP_SelectImportFile.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupRight", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Import", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_SelectImportFile.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnucancel_Internalname, "", "Cancel", bttBtnucancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOUCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_SelectImportFile.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0K2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_2-148375", 0) ;
            }
            Form.Meta.addItem("description", "Select file to import", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0K0( ) ;
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E110K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUCANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoUCancel' */
                              E120K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E130K2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E140K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E150K2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0K2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFiltertoupload_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E140K2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E150K2 ();
            WB0K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0K2( )
      {
         GxWebStd.gx_hidden_field( context, "vIMPORTTYPE", AV9ImportType);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMPORTTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ImportType, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMSGS", AV5ErrorMsgs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMSGS", AV5ErrorMsgs);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vERRORMSGS", GetSecureSignedToken( "", AV5ErrorMsgs, context));
         GxWebStd.gx_hidden_field( context, "vEXTRAPARMSJSON", AV6ExtraParmsJson);
         GxWebStd.gx_hidden_field( context, "gxhash_vEXTRAPARMSJSON", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ExtraParmsJson, "")), context));
         GxWebStd.gx_hidden_field( context, "vTRANSACTIONNAME", AV14TransactionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14TransactionName, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            edtavFiltertoupload_Filename = cgiGet( "vFILTERTOUPLOAD_Filename");
            /* Read variables values. */
            AV7FilterToUpload = cgiGet( edtavFiltertoupload_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7FilterToUpload)) )
            {
               GXCCtlgxBlob = "vFILTERTOUPLOAD" + "_gxBlob";
               AV7FilterToUpload = cgiGet( GXCCtlgxBlob);
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110K2 ();
         if (returnInSub) return;
      }

      protected void E110K2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E120K2( )
      {
         /* 'DoUCancel' Routine */
         returnInSub = false;
         GX_msglist.addItem("<#CLEAR#>");
         AV13Ret = true;
         AssignAttri("", false, "AV13Ret", AV13Ret);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E130K2 ();
         if (returnInSub) return;
      }

      protected void E130K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8FilterToUploadExt = edtavFiltertoupload_Filename;
         AV8FilterToUploadExt = ((StringUtil.StringSearch( AV8FilterToUploadExt, ".", 1)>0) ? StringUtil.Substring( AV8FilterToUploadExt, StringUtil.StringSearchRev( AV8FilterToUploadExt, ".", -1)+1, StringUtil.Len( AV8FilterToUploadExt)-StringUtil.StringSearchRev( AV8FilterToUploadExt, ".", -1)) : "");
         GX_msglist.addItem("<#CLEAR#>");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7FilterToUpload)) )
         {
            if ( ( ( StringUtil.StrCmp(StringUtil.Upper( AV8FilterToUploadExt), "CSV") == 0 ) && ( StringUtil.StrCmp(AV9ImportType, "CSV") == 0 ) ) || ( ( StringUtil.StrCmp(StringUtil.Upper( AV8FilterToUploadExt), "XLSX") == 0 ) && ( StringUtil.StrCmp(AV9ImportType, "Excel") == 0 ) ) )
            {
               AV12ResultMsg = "";
               if ( new GeneXus.Programs.wwpbaseobjects.wwp_importdata(context).executeUdp(  AV14TransactionName,  AV9ImportType,  AV7FilterToUpload,  AV6ExtraParmsJson, out  AV5ErrorMsgs) )
               {
                  AV10LastErrorType = 2;
                  AV17GXV1 = 1;
                  while ( AV17GXV1 <= AV5ErrorMsgs.Count )
                  {
                     AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV5ErrorMsgs.Item(AV17GXV1));
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ResultMsg)) )
                     {
                        AV12ResultMsg += StringUtil.NewLine( );
                        if ( ( AV10LastErrorType == 0 ) && ( AV11Message.gxTpr_Type == 2 ) )
                        {
                           AV12ResultMsg += StringUtil.NewLine( );
                        }
                     }
                     AV10LastErrorType = AV11Message.gxTpr_Type;
                     AV12ResultMsg += AV11Message.gxTpr_Description;
                     AV17GXV1 = (int)(AV17GXV1+1);
                  }
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "File import success",  AV12ResultMsg,  "success",  "",  "na",  ""));
                  AV13Ret = true;
                  AssignAttri("", false, "AV13Ret", AV13Ret);
                  context.DoAjaxRefresh();
               }
               else
               {
                  AV7FilterToUpload = "";
                  AssignProp("", false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV7FilterToUpload), true);
                  AV18GXV2 = 1;
                  while ( AV18GXV2 <= AV5ErrorMsgs.Count )
                  {
                     AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV5ErrorMsgs.Item(AV18GXV2));
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12ResultMsg)) )
                     {
                        AV12ResultMsg += StringUtil.NewLine( );
                        if ( StringUtil.StrCmp(AV11Message.gxTpr_Id, "WWP_LineId") == 0 )
                        {
                           AV12ResultMsg += StringUtil.NewLine( );
                        }
                     }
                     AV12ResultMsg += AV11Message.gxTpr_Description;
                     AV18GXV2 = (int)(AV18GXV2+1);
                  }
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error importing file",  AV12ResultMsg,  "error",  "",  "false",  ""));
               }
            }
            else
            {
               AV7FilterToUpload = "";
               AssignProp("", false, edtavFiltertoupload_Internalname, "URL", context.PathToRelativeUrl( AV7FilterToUpload), true);
               AV12ResultMsg = StringUtil.Format( "The expected file type is %1.", ((StringUtil.StrCmp(AV9ImportType, "CSV")==0) ? "csv" : "xlsx"), "", "", "", "", "", "", "", "");
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Invalid file type",  AV12ResultMsg,  "error",  "",  "na",  ""));
            }
         }
         else
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "File", "", "", "", "", "", "", "", ""));
         }
         /*  Sending Event outputs  */
      }

      protected void E140K2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( AV13Ret )
         {
            context.setWebReturnParms(new Object[] {(string)AV14TransactionName,(string)AV9ImportType,(string)AV6ExtraParmsJson});
            context.setWebReturnParmsMetadata(new Object[] {"AV14TransactionName","AV9ImportType","AV6ExtraParmsJson"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E150K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14TransactionName = (string)getParm(obj,0);
         AssignAttri("", false, "AV14TransactionName", AV14TransactionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14TransactionName, "")), context));
         AV9ImportType = (string)getParm(obj,1);
         AssignAttri("", false, "AV9ImportType", AV9ImportType);
         GxWebStd.gx_hidden_field( context, "gxhash_vIMPORTTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV9ImportType, "")), context));
         AV6ExtraParmsJson = (string)getParm(obj,2);
         AssignAttri("", false, "AV6ExtraParmsJson", AV6ExtraParmsJson);
         GxWebStd.gx_hidden_field( context, "gxhash_vEXTRAPARMSJSON", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6ExtraParmsJson, "")), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20219151154212", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("wwpbaseobjects/wwp_selectimportfile.js", "?20219151154212", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavFiltertoupload_Internalname = "vFILTERTOUPLOAD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtnucancel_Internalname = "BTNUCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavFiltertoupload_Jsonclick = "";
         edtavFiltertoupload_Parameters = "";
         edtavFiltertoupload_Contenttype = "";
         edtavFiltertoupload_Filetype = "";
         edtavFiltertoupload_Enabled = 1;
         edtavFiltertoupload_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Select file to import";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13Ret',fld:'vRET',pic:''},{av:'AV5ErrorMsgs',fld:'vERRORMSGS',pic:'',hsh:true},{av:'AV9ImportType',fld:'vIMPORTTYPE',pic:'',hsh:true},{av:'AV6ExtraParmsJson',fld:'vEXTRAPARMSJSON',pic:'',hsh:true},{av:'AV14TransactionName',fld:'vTRANSACTIONNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUCANCEL'","{handler:'E120K2',iparms:[]");
         setEventMetadata("'DOUCANCEL'",",oparms:[{av:'AV13Ret',fld:'vRET',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E130K2',iparms:[{av:'edtavFiltertoupload_Filename',ctrl:'vFILTERTOUPLOAD',prop:'Filename'},{av:'AV7FilterToUpload',fld:'vFILTERTOUPLOAD',pic:''},{av:'AV9ImportType',fld:'vIMPORTTYPE',pic:'',hsh:true},{av:'AV5ErrorMsgs',fld:'vERRORMSGS',pic:'',hsh:true},{av:'AV6ExtraParmsJson',fld:'vEXTRAPARMSJSON',pic:'',hsh:true},{av:'AV14TransactionName',fld:'vTRANSACTIONNAME',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13Ret',fld:'vRET',pic:''},{av:'AV7FilterToUpload',fld:'vFILTERTOUPLOAD',pic:''}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         wcpOAV14TransactionName = "";
         wcpOAV9ImportType = "";
         wcpOAV6ExtraParmsJson = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV5ErrorMsgs = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         GXKey = "";
         GXCCtlgxBlob = "";
         AV7FilterToUpload = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         bttBtnenter_Jsonclick = "";
         bttBtnucancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8FilterToUploadExt = "";
         AV12ResultMsg = "";
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV10LastErrorType ;
      private short nGXWrapped ;
      private int edtavFiltertoupload_Enabled ;
      private int AV17GXV1 ;
      private int AV18GXV2 ;
      private int idxLst ;
      private string edtavFiltertoupload_Filename ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXCCtlgxBlob ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableattributes_Internalname ;
      private string edtavFiltertoupload_Internalname ;
      private string TempTags ;
      private string edtavFiltertoupload_Filetype ;
      private string edtavFiltertoupload_Contenttype ;
      private string edtavFiltertoupload_Parameters ;
      private string edtavFiltertoupload_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnucancel_Internalname ;
      private string bttBtnucancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13Ret ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV14TransactionName ;
      private string AV9ImportType ;
      private string AV6ExtraParmsJson ;
      private string wcpOAV14TransactionName ;
      private string wcpOAV9ImportType ;
      private string wcpOAV6ExtraParmsJson ;
      private string AV8FilterToUploadExt ;
      private string AV12ResultMsg ;
      private string AV7FilterToUpload ;
      private GxFile gxblobfileaux ;
      private IGxDataStore dsDefault ;
      private string aP0_TransactionName ;
      private string aP1_ImportType ;
      private string aP2_ExtraParmsJson ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtMessages_Message> AV5ErrorMsgs ;
      private GXWebForm Form ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
   }

}
