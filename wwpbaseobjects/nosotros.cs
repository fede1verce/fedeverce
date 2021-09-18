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
   public class nosotros : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public nosotros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public nosotros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Fstestimonials") == 0 )
            {
               nRC_GXsfl_116 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_116"), "."));
               nGXsfl_116_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_116_idx"), "."));
               sGXsfl_116_idx = GetPar( "sGXsfl_116_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrFstestimonials_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Fstestimonials") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrFstestimonials_refresh( ) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
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
         PA0Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Q2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2021915229236", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.nosotros.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdthometestimonials", AV6SDTHomeTestimonials);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdthometestimonials", AV6SDTHomeTestimonials);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_116", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_116), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "FSTESTIMONIALS_Class", StringUtil.RTrim( subFstestimonials_Class));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Q2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwpbaseobjects.nosotros.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Nosotros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Nosotros" ;
      }

      protected void WB0Q0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusCustomersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHeadersection_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCustomerstitle_Internalname, "Nosotros", "", "", lblCustomerstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhite", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop80", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMainnumberstitlecc_Internalname, "Equipo de Trabajo", "", "", lblMainnumberstitlecc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSdf_Internalname, " ", "", "", lblSdf_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSdfa_Internalname, " ", "", "", lblSdfa_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSdfh_Internalname, " ", "", "", lblSdfh_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Center", "top", "", "", "div");
            wb_table1_30_0Q2( true) ;
         }
         else
         {
            wb_table1_30_0Q2( false) ;
         }
         return  ;
      }

      protected void wb_table1_30_0Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Center", "top", "", "", "div");
            wb_table2_46_0Q2( true) ;
         }
         else
         {
            wb_table2_46_0Q2( false) ;
         }
         return  ;
      }

      protected void wb_table2_46_0Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Center", "top", "", "", "div");
            wb_table3_62_0Q2( true) ;
         }
         else
         {
            wb_table3_62_0Q2( false) ;
         }
         return  ;
      }

      protected void wb_table3_62_0Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "Center", "top", "", "", "div");
            wb_table4_78_0Q2( true) ;
         }
         else
         {
            wb_table4_78_0Q2( false) ;
         }
         return  ;
      }

      protected void wb_table4_78_0Q2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAsd_Internalname, " ", "", "", lblAsd_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAsds_Internalname, " ", "", "", lblAsds_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAsdgg_Internalname, " ", "", "", lblAsdgg_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LandingPurusTestimonialsCell1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTestimonialssection_Internalname, 1, 0, "px", 0, "px", "TableContentLandingPurusTestimonials", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTestimonialstitle_Internalname, "Nuestro Proyecto", "", "", lblTestimonialstitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LandingPurusTitleWhiteWithUnderline", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingTop50", "left", "top", "", "", "div");
            /*  Grid Control  */
            FstestimonialsContainer.SetIsFreestyle(true);
            FstestimonialsContainer.SetWrapped(nGXWrapped);
            if ( FstestimonialsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"DivS\" data-gxgridid=\"116\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subFstestimonials_Internalname, subFstestimonials_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
            }
            else
            {
               FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
               FstestimonialsContainer.AddObjectProperty("Header", subFstestimonials_Header);
               FstestimonialsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
               FstestimonialsContainer.AddObjectProperty("Class", "FreeStyleGrid");
               FstestimonialsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Backcolorstyle), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("CmpContext", "");
               FstestimonialsContainer.AddObjectProperty("InMasterPage", "false");
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               FstestimonialsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0, ".", "")));
               FstestimonialsContainer.AddColumnProperties(FstestimonialsColumn);
               FstestimonialsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Selectedindex), 4, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowselection), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Selectioncolor), 9, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowhovering), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Hoveringcolor), 9, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Allowcollapsing), 1, 0, ".", "")));
               FstestimonialsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 116 )
         {
            wbEnd = 0;
            nRC_GXsfl_116 = (int)(nGXsfl_116_idx-1);
            if ( FstestimonialsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV26GXV1 = nGXsfl_116_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fstestimonials", FstestimonialsContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData", FstestimonialsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData"+"V", FstestimonialsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FstestimonialsContainerData"+"V"+"\" value='"+FstestimonialsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
         if ( wbEnd == 116 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( FstestimonialsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV26GXV1 = nGXsfl_116_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"FstestimonialsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Fstestimonials", FstestimonialsContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData", FstestimonialsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "FstestimonialsContainerData"+"V", FstestimonialsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"FstestimonialsContainerData"+"V"+"\" value='"+FstestimonialsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Q2( )
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
            Form.Meta.addItem("description", "Nosotros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Q0( ) ;
      }

      protected void WS0Q2( )
      {
         START0Q2( ) ;
         EVT0Q2( ) ;
      }

      protected void EVT0Q2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "FSTESTIMONIALS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_116_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
                              SubsflControlProps_1162( ) ;
                              AV26GXV1 = nGXsfl_116_idx;
                              if ( ( AV6SDTHomeTestimonials.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
                              {
                                 AV6SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV26GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "FSTESTIMONIALS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E120Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Q2( )
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

      protected void PA0Q2( )
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
               GX_FocusControl = edtavTitle_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrFstestimonials_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1162( ) ;
         while ( nGXsfl_116_idx <= nRC_GXsfl_116 )
         {
            sendrow_1162( ) ;
            nGXsfl_116_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_116_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
            sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
            SubsflControlProps_1162( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( FstestimonialsContainer)) ;
         /* End function gxnrFstestimonials_newrow */
      }

      protected void gxgrFstestimonials_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         FSTESTIMONIALS_nCurrentRecord = 0;
         RF0Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrFstestimonials_refresh */
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
         RF0Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTitle_Enabled = 0;
         AssignProp("", false, edtavTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle_Enabled), 5, 0), true);
         edtavSubtitle_Enabled = 0;
         AssignProp("", false, edtavSubtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle_Enabled), 5, 0), true);
         edtavTitle2_Enabled = 0;
         AssignProp("", false, edtavTitle2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle2_Enabled), 5, 0), true);
         edtavSubtitle2_Enabled = 0;
         AssignProp("", false, edtavSubtitle2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle2_Enabled), 5, 0), true);
         edtavTitle3_Enabled = 0;
         AssignProp("", false, edtavTitle3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle3_Enabled), 5, 0), true);
         edtavSubtitle3_Enabled = 0;
         AssignProp("", false, edtavSubtitle3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle3_Enabled), 5, 0), true);
         edtavTitle4_Enabled = 0;
         AssignProp("", false, edtavTitle4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle4_Enabled), 5, 0), true);
         edtavSubtitle4_Enabled = 0;
         AssignProp("", false, edtavSubtitle4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle4_Enabled), 5, 0), true);
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0), !bGXsfl_116_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0), !bGXsfl_116_Refreshing);
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialscompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0), !bGXsfl_116_Refreshing);
      }

      protected void RF0Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            FstestimonialsContainer.ClearRows();
         }
         wbStart = 116;
         nGXsfl_116_idx = 1;
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         bGXsfl_116_Refreshing = true;
         FstestimonialsContainer.AddObjectProperty("GridName", "Fstestimonials");
         FstestimonialsContainer.AddObjectProperty("CmpContext", "");
         FstestimonialsContainer.AddObjectProperty("InMasterPage", "false");
         FstestimonialsContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         FstestimonialsContainer.AddObjectProperty("Class", "FreeStyleGrid");
         FstestimonialsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         FstestimonialsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         FstestimonialsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subFstestimonials_Backcolorstyle), 1, 0, ".", "")));
         FstestimonialsContainer.PageSize = subFstestimonials_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1162( ) ;
            E120Q2 ();
            wbEnd = 116;
            WB0Q0( ) ;
         }
         bGXsfl_116_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Q2( )
      {
      }

      protected int subFstestimonials_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subFstestimonials_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTitle_Enabled = 0;
         AssignProp("", false, edtavTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle_Enabled), 5, 0), true);
         edtavSubtitle_Enabled = 0;
         AssignProp("", false, edtavSubtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle_Enabled), 5, 0), true);
         edtavTitle2_Enabled = 0;
         AssignProp("", false, edtavTitle2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle2_Enabled), 5, 0), true);
         edtavSubtitle2_Enabled = 0;
         AssignProp("", false, edtavSubtitle2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle2_Enabled), 5, 0), true);
         edtavTitle3_Enabled = 0;
         AssignProp("", false, edtavTitle3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle3_Enabled), 5, 0), true);
         edtavSubtitle3_Enabled = 0;
         AssignProp("", false, edtavSubtitle3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle3_Enabled), 5, 0), true);
         edtavTitle4_Enabled = 0;
         AssignProp("", false, edtavTitle4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTitle4_Enabled), 5, 0), true);
         edtavSubtitle4_Enabled = 0;
         AssignProp("", false, edtavSubtitle4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSubtitle4_Enabled), 5, 0), true);
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsdescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsdescription_Enabled), 5, 0), !bGXsfl_116_Refreshing);
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialsname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialsname_Enabled), 5, 0), !bGXsfl_116_Refreshing);
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         AssignProp("", false, edtavSdthometestimonials__sdthometestimonialscompany_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdthometestimonials__sdthometestimonialscompany_Enabled), 5, 0), !bGXsfl_116_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdthometestimonials"), AV6SDTHomeTestimonials);
            /* Read saved values. */
            nRC_GXsfl_116 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_116"), ",", "."));
            subFstestimonials_Class = cgiGet( "FSTESTIMONIALS_Class");
            nRC_GXsfl_116 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_116"), ",", "."));
            nGXsfl_116_fel_idx = 0;
            while ( nGXsfl_116_fel_idx < nRC_GXsfl_116 )
            {
               nGXsfl_116_fel_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_116_fel_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_fel_idx+1);
               sGXsfl_116_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1162( ) ;
               AV26GXV1 = nGXsfl_116_fel_idx;
               if ( ( AV6SDTHomeTestimonials.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
               {
                  AV6SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV26GXV1));
               }
            }
            if ( nGXsfl_116_fel_idx == 0 )
            {
               nGXsfl_116_idx = 1;
               sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
               SubsflControlProps_1162( ) ;
            }
            nGXsfl_116_fel_idx = 1;
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
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
         E110Q2 ();
         if (returnInSub) return;
      }

      protected void E110Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1 = AV5SDTHomeLandingSampleLogos;
         new GeneXus.Programs.wwpbaseobjects.homelandingcustomerlogos(context ).execute( out  GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1) ;
         AV5SDTHomeLandingSampleLogos = GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1;
         GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 = AV6SDTHomeTestimonials;
         new GeneXus.Programs.wwpbaseobjects.hometestimonials(context ).execute( out  GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2) ;
         AV6SDTHomeTestimonials = GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2;
         gx_BV116 = true;
         AV7WebSession.Set("IsLandingPage", "S");
         AV12Image = context.convertURL( (string)(context.GetImagePath( "6e9fe416-a1ce-4719-a5cc-441f4f68854f", "", context.GetTheme( ))));
         AssignProp("", false, imgavImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV12Image)) ? AV30Image_GXI : context.convertURL( context.PathToRelativeUrl( AV12Image))), true);
         AssignProp("", false, imgavImage_Internalname, "SrcSet", context.GetImageSrcSet( AV12Image), true);
         AV13Title = "Dino Vidili";
         AssignAttri("", false, "AV13Title", AV13Title);
         AV14Subtitle = "Managing Director";
         AssignAttri("", false, "AV14Subtitle", AV14Subtitle);
         AV15Image2 = context.convertURL( (string)(context.GetImagePath( "4404ee98-13bf-4a0b-8558-1c00cf9351b9", "", context.GetTheme( ))));
         AssignProp("", false, imgavImage2_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV15Image2)) ? AV31Image2_GXI : context.convertURL( context.PathToRelativeUrl( AV15Image2))), true);
         AssignProp("", false, imgavImage2_Internalname, "SrcSet", context.GetImageSrcSet( AV15Image2), true);
         AV16Title2 = "Diego Gonzalez";
         AssignAttri("", false, "AV16Title2", AV16Title2);
         AV17Subtitle2 = "Area Proyectos e Innovacion";
         AssignAttri("", false, "AV17Subtitle2", AV17Subtitle2);
         AV18Image3 = context.convertURL( (string)(context.GetImagePath( "64c3570e-4c48-4f7a-9342-1ebecdd7179f", "", context.GetTheme( ))));
         AssignProp("", false, imgavImage3_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV18Image3)) ? AV32Image3_GXI : context.convertURL( context.PathToRelativeUrl( AV18Image3))), true);
         AssignProp("", false, imgavImage3_Internalname, "SrcSet", context.GetImageSrcSet( AV18Image3), true);
         AV19Title3 = "Claudio Tome";
         AssignAttri("", false, "AV19Title3", AV19Title3);
         AV20Subtitle3 = "Area Operaciones y Optimizacion de Procesos";
         AssignAttri("", false, "AV20Subtitle3", AV20Subtitle3);
         AV21Image4 = context.convertURL( (string)(context.GetImagePath( "69b5476d-2507-4def-b95f-4088077414ce", "", context.GetTheme( ))));
         AssignProp("", false, imgavImage4_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV21Image4)) ? AV33Image4_GXI : context.convertURL( context.PathToRelativeUrl( AV21Image4))), true);
         AssignProp("", false, imgavImage4_Internalname, "SrcSet", context.GetImageSrcSet( AV21Image4), true);
         AV22Title4 = "Martin Crescimone";
         AssignAttri("", false, "AV22Title4", AV22Title4);
         AV23Subtitle4 = "Area Supply Chain & Negocios Internacionales";
         AssignAttri("", false, "AV23Subtitle4", AV23Subtitle4);
      }

      private void E120Q2( )
      {
         /* Fstestimonials_Load Routine */
         returnInSub = false;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV6SDTHomeTestimonials.Count )
         {
            AV6SDTHomeTestimonials.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV26GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 116;
            }
            sendrow_1162( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_116_Refreshing )
            {
               context.DoAjaxLoad(116, FstestimonialsRow);
            }
            AV26GXV1 = (int)(AV26GXV1+1);
         }
      }

      protected void wb_table4_78_0Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletopinfo4_Internalname, tblTabletopinfo4_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Image4", "gx-form-item CardSmallImageAttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "CardSmallImageAttribute";
            StyleString = "";
            AV21Image4_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV21Image4))&&String.IsNullOrEmpty(StringUtil.RTrim( AV33Image4_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV21Image4)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21Image4)) ? AV33Image4_GXI : context.PathToRelativeUrl( AV21Image4));
            GxWebStd.gx_bitmap( context, imgavImage4_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV21Image4_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle4_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle4_Internalname, "Title4", "col-sm-3 SimpleCardAttributeTitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle4_Internalname, AV22Title4, StringUtil.RTrim( context.localUtil.Format( AV22Title4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitle4_Jsonclick, 0, "SimpleCardAttributeTitle", "", "", "", "", 1, edtavTitle4_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSubtitle4_Internalname, "Subtitle4", "col-sm-3 SimpleCardAttributeSubtitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSubtitle4_Internalname, AV23Subtitle4, StringUtil.RTrim( context.localUtil.Format( AV23Subtitle4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSubtitle4_Jsonclick, 0, "SimpleCardAttributeSubtitle", "", "", "", "", 1, edtavSubtitle4_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_78_0Q2e( true) ;
         }
         else
         {
            wb_table4_78_0Q2e( false) ;
         }
      }

      protected void wb_table3_62_0Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletopinfo3_Internalname, tblTabletopinfo3_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Image3", "gx-form-item CardSmallImageAttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "CardSmallImageAttribute";
            StyleString = "";
            AV18Image3_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV18Image3))&&String.IsNullOrEmpty(StringUtil.RTrim( AV32Image3_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV18Image3)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV18Image3)) ? AV32Image3_GXI : context.PathToRelativeUrl( AV18Image3));
            GxWebStd.gx_bitmap( context, imgavImage3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV18Image3_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle3_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle3_Internalname, "Title3", "col-sm-3 SimpleCardAttributeTitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle3_Internalname, AV19Title3, StringUtil.RTrim( context.localUtil.Format( AV19Title3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitle3_Jsonclick, 0, "SimpleCardAttributeTitle", "", "", "", "", 1, edtavTitle3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSubtitle3_Internalname, "Subtitle3", "col-sm-3 SimpleCardAttributeSubtitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSubtitle3_Internalname, AV20Subtitle3, StringUtil.RTrim( context.localUtil.Format( AV20Subtitle3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSubtitle3_Jsonclick, 0, "SimpleCardAttributeSubtitle", "", "", "", "", 1, edtavSubtitle3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_62_0Q2e( true) ;
         }
         else
         {
            wb_table3_62_0Q2e( false) ;
         }
      }

      protected void wb_table2_46_0Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletopinfo2_Internalname, tblTabletopinfo2_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Image2", "gx-form-item CardSmallImageAttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "CardSmallImageAttribute";
            StyleString = "";
            AV15Image2_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV15Image2))&&String.IsNullOrEmpty(StringUtil.RTrim( AV31Image2_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV15Image2)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV15Image2)) ? AV31Image2_GXI : context.PathToRelativeUrl( AV15Image2));
            GxWebStd.gx_bitmap( context, imgavImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV15Image2_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle2_Internalname, "Title2", "col-sm-3 SimpleCardAttributeTitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle2_Internalname, AV16Title2, StringUtil.RTrim( context.localUtil.Format( AV16Title2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitle2_Jsonclick, 0, "SimpleCardAttributeTitle", "", "", "", "", 1, edtavTitle2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSubtitle2_Internalname, "Subtitle2", "col-sm-3 SimpleCardAttributeSubtitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSubtitle2_Internalname, AV17Subtitle2, StringUtil.RTrim( context.localUtil.Format( AV17Subtitle2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSubtitle2_Jsonclick, 0, "SimpleCardAttributeSubtitle", "", "", "", "", 1, edtavSubtitle2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_46_0Q2e( true) ;
         }
         else
         {
            wb_table2_46_0Q2e( false) ;
         }
      }

      protected void wb_table1_30_0Q2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabletopinfo_Internalname, tblTabletopinfo_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Image", "gx-form-item CardSmallImageAttributeLabel", 0, true, "width: 25%;");
            /* Static Bitmap Variable */
            ClassString = "CardSmallImageAttribute";
            StyleString = "";
            AV12Image_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV12Image))&&String.IsNullOrEmpty(StringUtil.RTrim( AV30Image_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV12Image)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV12Image)) ? AV30Image_GXI : context.PathToRelativeUrl( AV12Image));
            GxWebStd.gx_bitmap( context, imgavImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV12Image_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTitle_Internalname, "Title", "col-sm-3 SimpleCardAttributeTitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTitle_Internalname, AV13Title, StringUtil.RTrim( context.localUtil.Format( AV13Title, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTitle_Jsonclick, 0, "SimpleCardAttributeTitle", "", "", "", "", 1, edtavTitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSubtitle_Internalname, "Subtitle", "col-sm-3 SimpleCardAttributeSubtitleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_116_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSubtitle_Internalname, AV14Subtitle, StringUtil.RTrim( context.localUtil.Format( AV14Subtitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSubtitle_Jsonclick, 0, "SimpleCardAttributeSubtitle", "", "", "", "", 1, edtavSubtitle_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, false, "", "left", true, "", "HLP_WWPBaseObjects\\Nosotros.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_30_0Q2e( true) ;
         }
         else
         {
            wb_table1_30_0Q2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0Q2( ) ;
         WS0Q2( ) ;
         WE0Q2( ) ;
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
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddStyleSheetFile("HorizontalGrid/horizontalgrid.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20219152292386", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wwpbaseobjects/nosotros.js", "?20219152292386", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
            context.AddJavascriptSource("HorizontalGrid/horizontalgrid.min.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1162( )
      {
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION_"+sGXsfl_116_idx;
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME_"+sGXsfl_116_idx;
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY_"+sGXsfl_116_idx;
      }

      protected void SubsflControlProps_fel_1162( )
      {
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION_"+sGXsfl_116_fel_idx;
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME_"+sGXsfl_116_fel_idx;
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY_"+sGXsfl_116_fel_idx;
      }

      protected void sendrow_1162( )
      {
         SubsflControlProps_1162( ) ;
         WB0Q0( ) ;
         FstestimonialsRow = GXWebRow.GetNew(context,FstestimonialsContainer);
         if ( subFstestimonials_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subFstestimonials_Backstyle = 0;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
            }
         }
         else if ( subFstestimonials_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subFstestimonials_Backstyle = 0;
            subFstestimonials_Backcolor = subFstestimonials_Allbackcolor;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Uniform";
            }
         }
         else if ( subFstestimonials_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subFstestimonials_Backstyle = 1;
            if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
            {
               subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
            }
            subFstestimonials_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subFstestimonials_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subFstestimonials_Backstyle = 1;
            if ( ((int)((nGXsfl_116_idx) % (2))) == 0 )
            {
               subFstestimonials_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
               {
                  subFstestimonials_Linesclass = subFstestimonials_Class+"Even";
               }
            }
            else
            {
               subFstestimonials_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subFstestimonials_Class, "") != 0 )
               {
                  subFstestimonials_Linesclass = subFstestimonials_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( FstestimonialsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subFstestimonials_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_116_idx+"\">") ;
         }
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtablefsfstestimonials_Internalname+"_"+sGXsfl_116_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 TableLandingPurusTestimonials",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsdescription_Internalname,(string)"SDTHome Testimonials Description",(string)"col-sm-3 AttributeLandingPurusTestimonialDescriptionLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Multiple line edit */
         ClassString = "AttributeLandingPurusTestimonialDescription";
         StyleString = "";
         ClassString = "AttributeLandingPurusTestimonialDescription";
         StyleString = "";
         FstestimonialsRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsdescription_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV26GXV1)).gxTpr_Sdthometestimonialsdescription,(string)"",(string)"",(short)0,(short)1,(int)edtavSdthometestimonials__sdthometestimonialsdescription_Enabled,(short)0,(short)80,(string)"chr",(short)5,(string)"row",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"400",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)false,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(short)0});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 LandingPurusTestimonialTitleCell",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divUnnamedtable3_Internalname+"_"+sGXsfl_116_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsname_Internalname,(string)"SDTHome Testimonials Name",(string)"col-sm-3 AttributeLandingPurusTestimonialTitleLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusTestimonialTitle";
         FstestimonialsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialsname_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV26GXV1)).gxTpr_Sdthometestimonialsname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdthometestimonials__sdthometestimonialsname_Jsonclick,(short)0,(string)"AttributeLandingPurusTestimonialTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdthometestimonials__sdthometestimonialsname_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)116,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Div Control */
         FstestimonialsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Attribute/Variable Label */
         FstestimonialsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialscompany_Internalname,(string)"SDTHome Testimonials Company",(string)"col-sm-3 AttributeLandingPurusTestimonialSubtitleLabel",(short)0,(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         /* Single line edit */
         ROClassString = "AttributeLandingPurusTestimonialSubtitle";
         FstestimonialsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdthometestimonials__sdthometestimonialscompany_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem)AV6SDTHomeTestimonials.Item(AV26GXV1)).gxTpr_Sdthometestimonialscompany,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick,(short)0,(string)"AttributeLandingPurusTestimonialSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavSdthometestimonials__sdthometestimonialscompany_Enabled,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)116,(short)1,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         FstestimonialsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         FstestimonialsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         FstestimonialsRow.AddRenderProperties(FstestimonialsColumn);
         send_integrity_lvl_hashes0Q2( ) ;
         /* End of Columns property logic. */
         FstestimonialsContainer.AddRow(FstestimonialsRow);
         nGXsfl_116_idx = ((subFstestimonials_Islastpage==1)&&(nGXsfl_116_idx+1>subFstestimonials_fnc_Recordsperpage( )) ? 1 : nGXsfl_116_idx+1);
         sGXsfl_116_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_116_idx), 4, 0), 4, "0");
         SubsflControlProps_1162( ) ;
         /* End function sendrow_1162 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblCustomerstitle_Internalname = "CUSTOMERSTITLE";
         divHeadersection_Internalname = "HEADERSECTION";
         lblMainnumberstitlecc_Internalname = "MAINNUMBERSTITLECC";
         lblSdf_Internalname = "SDF";
         lblSdfa_Internalname = "SDFA";
         lblSdfh_Internalname = "SDFH";
         imgavImage_Internalname = "vIMAGE";
         edtavTitle_Internalname = "vTITLE";
         edtavSubtitle_Internalname = "vSUBTITLE";
         divTabletitle_Internalname = "TABLETITLE";
         tblTabletopinfo_Internalname = "TABLETOPINFO";
         imgavImage2_Internalname = "vIMAGE2";
         edtavTitle2_Internalname = "vTITLE2";
         edtavSubtitle2_Internalname = "vSUBTITLE2";
         divTabletitle2_Internalname = "TABLETITLE2";
         tblTabletopinfo2_Internalname = "TABLETOPINFO2";
         imgavImage3_Internalname = "vIMAGE3";
         edtavTitle3_Internalname = "vTITLE3";
         edtavSubtitle3_Internalname = "vSUBTITLE3";
         divTabletitle3_Internalname = "TABLETITLE3";
         tblTabletopinfo3_Internalname = "TABLETOPINFO3";
         imgavImage4_Internalname = "vIMAGE4";
         edtavTitle4_Internalname = "vTITLE4";
         edtavSubtitle4_Internalname = "vSUBTITLE4";
         divTabletitle4_Internalname = "TABLETITLE4";
         tblTabletopinfo4_Internalname = "TABLETOPINFO4";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         lblAsd_Internalname = "ASD";
         lblAsds_Internalname = "ASDS";
         lblAsdgg_Internalname = "ASDGG";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTestimonialstitle_Internalname = "TESTIMONIALSTITLE";
         edtavSdthometestimonials__sdthometestimonialsdescription_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSDESCRIPTION";
         edtavSdthometestimonials__sdthometestimonialsname_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSNAME";
         edtavSdthometestimonials__sdthometestimonialscompany_Internalname = "SDTHOMETESTIMONIALS__SDTHOMETESTIMONIALSCOMPANY";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         divUnnamedtablefsfstestimonials_Internalname = "UNNAMEDTABLEFSFSTESTIMONIALS";
         divTestimonialssection_Internalname = "TESTIMONIALSSECTION";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subFstestimonials_Internalname = "FSTESTIMONIALS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick = "";
         edtavSdthometestimonials__sdthometestimonialsname_Jsonclick = "";
         edtavSubtitle_Jsonclick = "";
         edtavSubtitle_Enabled = 1;
         edtavTitle_Jsonclick = "";
         edtavTitle_Enabled = 1;
         edtavSubtitle2_Jsonclick = "";
         edtavSubtitle2_Enabled = 1;
         edtavTitle2_Jsonclick = "";
         edtavTitle2_Enabled = 1;
         edtavSubtitle3_Jsonclick = "";
         edtavSubtitle3_Enabled = 1;
         edtavTitle3_Jsonclick = "";
         edtavTitle3_Enabled = 1;
         edtavSubtitle4_Jsonclick = "";
         edtavSubtitle4_Enabled = 1;
         edtavTitle4_Jsonclick = "";
         edtavTitle4_Enabled = 1;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = -1;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = -1;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = -1;
         subFstestimonials_Allowcollapsing = 0;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         subFstestimonials_Backcolorstyle = 0;
         subFstestimonials_Class = "FreeStyleGrid";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Nosotros";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'FSTESTIMONIALS_nFirstRecordOnPage'},{av:'FSTESTIMONIALS_nEOF'},{av:'AV6SDTHomeTestimonials',fld:'vSDTHOMETESTIMONIALS',grid:116,pic:''},{av:'nRC_GXsfl_116',ctrl:'FSTESTIMONIALS',prop:'GridRC'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("FSTESTIMONIALS.LOAD","{handler:'E120Q2',iparms:[]");
         setEventMetadata("FSTESTIMONIALS.LOAD",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6SDTHomeTestimonials = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblCustomerstitle_Jsonclick = "";
         lblMainnumberstitlecc_Jsonclick = "";
         lblSdf_Jsonclick = "";
         lblSdfa_Jsonclick = "";
         lblSdfh_Jsonclick = "";
         lblAsd_Jsonclick = "";
         lblAsds_Jsonclick = "";
         lblAsdgg_Jsonclick = "";
         lblTestimonialstitle_Jsonclick = "";
         FstestimonialsContainer = new GXWebGrid( context);
         sStyleString = "";
         subFstestimonials_Header = "";
         FstestimonialsColumn = new GXWebColumn();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5SDTHomeLandingSampleLogos = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem>( context, "SDTHomeLandingSampleLogosItem", "SsumarGroupDemo");
         GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem>( context, "SDTHomeLandingSampleLogosItem", "SsumarGroupDemo");
         GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem>( context, "SDTHomeTestimonialsItem", "SsumarGroupDemo");
         AV7WebSession = context.GetSession();
         AV12Image = "";
         AV30Image_GXI = "";
         AV13Title = "";
         AV14Subtitle = "";
         AV15Image2 = "";
         AV31Image2_GXI = "";
         AV16Title2 = "";
         AV17Subtitle2 = "";
         AV18Image3 = "";
         AV32Image3_GXI = "";
         AV19Title3 = "";
         AV20Subtitle3 = "";
         AV21Image4 = "";
         AV33Image4_GXI = "";
         AV22Title4 = "";
         AV23Subtitle4 = "";
         FstestimonialsRow = new GXWebRow();
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subFstestimonials_Linesclass = "";
         ROClassString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTitle_Enabled = 0;
         edtavSubtitle_Enabled = 0;
         edtavTitle2_Enabled = 0;
         edtavSubtitle2_Enabled = 0;
         edtavTitle3_Enabled = 0;
         edtavSubtitle3_Enabled = 0;
         edtavTitle4_Enabled = 0;
         edtavSubtitle4_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsdescription_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialsname_Enabled = 0;
         edtavSdthometestimonials__sdthometestimonialscompany_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short subFstestimonials_Backcolorstyle ;
      private short subFstestimonials_Allowselection ;
      private short subFstestimonials_Allowhovering ;
      private short subFstestimonials_Allowcollapsing ;
      private short subFstestimonials_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subFstestimonials_Backstyle ;
      private short FSTESTIMONIALS_nEOF ;
      private int nRC_GXsfl_116 ;
      private int nGXsfl_116_idx=1 ;
      private int edtavSdthometestimonials__sdthometestimonialsdescription_Enabled ;
      private int edtavSdthometestimonials__sdthometestimonialsname_Enabled ;
      private int edtavSdthometestimonials__sdthometestimonialscompany_Enabled ;
      private int subFstestimonials_Selectedindex ;
      private int subFstestimonials_Selectioncolor ;
      private int subFstestimonials_Hoveringcolor ;
      private int AV26GXV1 ;
      private int subFstestimonials_Islastpage ;
      private int edtavTitle_Enabled ;
      private int edtavSubtitle_Enabled ;
      private int edtavTitle2_Enabled ;
      private int edtavSubtitle2_Enabled ;
      private int edtavTitle3_Enabled ;
      private int edtavSubtitle3_Enabled ;
      private int edtavTitle4_Enabled ;
      private int edtavSubtitle4_Enabled ;
      private int nGXsfl_116_fel_idx=1 ;
      private int idxLst ;
      private int subFstestimonials_Backcolor ;
      private int subFstestimonials_Allbackcolor ;
      private long FSTESTIMONIALS_nCurrentRecord ;
      private long FSTESTIMONIALS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_116_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subFstestimonials_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divHeadersection_Internalname ;
      private string lblCustomerstitle_Internalname ;
      private string lblCustomerstitle_Jsonclick ;
      private string lblMainnumberstitlecc_Internalname ;
      private string lblMainnumberstitlecc_Jsonclick ;
      private string lblSdf_Internalname ;
      private string lblSdf_Jsonclick ;
      private string lblSdfa_Internalname ;
      private string lblSdfa_Jsonclick ;
      private string lblSdfh_Internalname ;
      private string lblSdfh_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string divUnnamedtable4_Internalname ;
      private string lblAsd_Internalname ;
      private string lblAsd_Jsonclick ;
      private string lblAsds_Internalname ;
      private string lblAsds_Jsonclick ;
      private string lblAsdgg_Internalname ;
      private string lblAsdgg_Jsonclick ;
      private string divTestimonialssection_Internalname ;
      private string lblTestimonialstitle_Internalname ;
      private string lblTestimonialstitle_Jsonclick ;
      private string sStyleString ;
      private string subFstestimonials_Internalname ;
      private string subFstestimonials_Header ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavTitle_Internalname ;
      private string edtavSubtitle_Internalname ;
      private string edtavTitle2_Internalname ;
      private string edtavSubtitle2_Internalname ;
      private string edtavTitle3_Internalname ;
      private string edtavSubtitle3_Internalname ;
      private string edtavTitle4_Internalname ;
      private string edtavSubtitle4_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialsdescription_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialsname_Internalname ;
      private string edtavSdthometestimonials__sdthometestimonialscompany_Internalname ;
      private string sGXsfl_116_fel_idx="0001" ;
      private string imgavImage_Internalname ;
      private string imgavImage2_Internalname ;
      private string imgavImage3_Internalname ;
      private string imgavImage4_Internalname ;
      private string tblTabletopinfo4_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string divTabletitle4_Internalname ;
      private string TempTags ;
      private string edtavTitle4_Jsonclick ;
      private string edtavSubtitle4_Jsonclick ;
      private string tblTabletopinfo3_Internalname ;
      private string divTabletitle3_Internalname ;
      private string edtavTitle3_Jsonclick ;
      private string edtavSubtitle3_Jsonclick ;
      private string tblTabletopinfo2_Internalname ;
      private string divTabletitle2_Internalname ;
      private string edtavTitle2_Jsonclick ;
      private string edtavSubtitle2_Jsonclick ;
      private string tblTabletopinfo_Internalname ;
      private string divTabletitle_Internalname ;
      private string edtavTitle_Jsonclick ;
      private string edtavSubtitle_Jsonclick ;
      private string subFstestimonials_Linesclass ;
      private string divUnnamedtablefsfstestimonials_Internalname ;
      private string divUnnamedtable3_Internalname ;
      private string ROClassString ;
      private string edtavSdthometestimonials__sdthometestimonialsname_Jsonclick ;
      private string edtavSdthometestimonials__sdthometestimonialscompany_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_116_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV116 ;
      private bool AV21Image4_IsBlob ;
      private bool AV18Image3_IsBlob ;
      private bool AV15Image2_IsBlob ;
      private bool AV12Image_IsBlob ;
      private string AV30Image_GXI ;
      private string AV13Title ;
      private string AV14Subtitle ;
      private string AV31Image2_GXI ;
      private string AV16Title2 ;
      private string AV17Subtitle2 ;
      private string AV32Image3_GXI ;
      private string AV19Title3 ;
      private string AV20Subtitle3 ;
      private string AV33Image4_GXI ;
      private string AV22Title4 ;
      private string AV23Subtitle4 ;
      private string AV12Image ;
      private string AV15Image2 ;
      private string AV18Image3 ;
      private string AV21Image4 ;
      private GXWebGrid FstestimonialsContainer ;
      private GXWebRow FstestimonialsRow ;
      private GXWebColumn FstestimonialsColumn ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV7WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem> AV5SDTHomeLandingSampleLogos ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem> GXt_objcol_SdtSDTHomeLandingSampleLogos_SDTHomeLandingSampleLogosItem1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> AV6SDTHomeTestimonials ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtSDTHomeTestimonials_SDTHomeTestimonialsItem> GXt_objcol_SdtSDTHomeTestimonials_SDTHomeTestimonialsItem2 ;
      private GXWebForm Form ;
   }

}
