using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using AVProEdgeMXNetLib.Enums;
using AVProEdgeMXNetLib.Components.Abstract;
using AVProEdgeMXNetLib.Components;
using AVProEdgeMXNetLib.Models;
using AVProEdgeMXNetLib.Models.Endpoints;
using AVProEdgeMXNetLib.Utilities;
using AVProEdgeMXNetLib;
using AVProEdgeMXNetLib.EventArguments;
using AVProEdgeMXNetLib.Models.Layouts;
using AVProEdgeMXNetLib.JsonSupport;
using AVProEdgeMXNetLib.Interfaces;
using AVProEdgeMXNetLib.Enums.Attributes;
using CCI.SimplSharp.Library.Comm.Priority;
using CCI.SimplSharp.Library.Comm.Common;
using CCI.SimplSharp.Library.Comm.Model;
using CCI.SimplSharp.Library.Comm.Equality;
using CCI.SimplSharp.Library.Components.States;
using CCI.SimplSharp.Library.Components.EventArguments;
using CCI.SimplSharp.Library.Components.Common;
using CCI.SimplSharp.Library.Components.Registration;
using CCI.SimplSharp.Library.IO.Utilities;
using CCI.SimplSharp.Library.IO.Common;

namespace UserModule_AVPRO_EDGE_MXNET_IRPORT_V1_2
{
    public class UserModuleClass_AVPRO_EDGE_MXNET_IRPORT_V1_2 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput IRSEND;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> COMMANDSEND;
        Crestron.Logos.SplusObjects.StringInput IRTX;
        UShortParameter COMMANDPROCESSORID;
        UShortParameter DEVICETYPE;
        UShortParameter MATRIXINDEX;
        InOutArray<StringParameter> COMMANDSTRING;
        AVProEdgeMXNetLib.Components.IrPortComponent IRPORT;
        object IRSEND_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 105;
                IRPORT . SendCommand ( IRTX .ToString()) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object COMMANDSEND_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort INDEX = 0;
            
            
            __context__.SourceCodeLine = 113;
            INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 115;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INDEX <= 10 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (COMMANDSTRING[ INDEX ] != "") )) ))  ) ) 
                {
                __context__.SourceCodeLine = 116;
                IRPORT . SendCommand ( COMMANDSTRING[ INDEX ] .ToString()) ; 
                }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 125;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 127;
        IRPORT . Configure ( (ushort)( COMMANDPROCESSORID  .Value ), (ushort)( DEVICETYPE  .Value ), (ushort)( MATRIXINDEX  .Value )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    IRSEND = new Crestron.Logos.SplusObjects.DigitalInput( IRSEND__DigitalInput__, this );
    m_DigitalInputList.Add( IRSEND__DigitalInput__, IRSEND );
    
    COMMANDSEND = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        COMMANDSEND[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( COMMANDSEND__DigitalInput__ + i, COMMANDSEND__DigitalInput__, this );
        m_DigitalInputList.Add( COMMANDSEND__DigitalInput__ + i, COMMANDSEND[i+1] );
    }
    
    IRTX = new Crestron.Logos.SplusObjects.StringInput( IRTX__AnalogSerialInput__, 65534, this );
    m_StringInputList.Add( IRTX__AnalogSerialInput__, IRTX );
    
    COMMANDPROCESSORID = new UShortParameter( COMMANDPROCESSORID__Parameter__, this );
    m_ParameterList.Add( COMMANDPROCESSORID__Parameter__, COMMANDPROCESSORID );
    
    DEVICETYPE = new UShortParameter( DEVICETYPE__Parameter__, this );
    m_ParameterList.Add( DEVICETYPE__Parameter__, DEVICETYPE );
    
    MATRIXINDEX = new UShortParameter( MATRIXINDEX__Parameter__, this );
    m_ParameterList.Add( MATRIXINDEX__Parameter__, MATRIXINDEX );
    
    COMMANDSTRING = new InOutArray<StringParameter>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        COMMANDSTRING[i+1] = new StringParameter( COMMANDSTRING__Parameter__ + i, COMMANDSTRING__Parameter__, this );
        m_ParameterList.Add( COMMANDSTRING__Parameter__ + i, COMMANDSTRING[i+1] );
    }
    
    
    IRSEND.OnDigitalPush.Add( new InputChangeHandlerWrapper( IRSEND_OnPush_0, true ) );
    for( uint i = 0; i < 10; i++ )
        COMMANDSEND[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( COMMANDSEND_OnPush_1, true ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    IRPORT  = new AVProEdgeMXNetLib.Components.IrPortComponent();
    
    
}

public UserModuleClass_AVPRO_EDGE_MXNET_IRPORT_V1_2 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint IRSEND__DigitalInput__ = 0;
const uint COMMANDSEND__DigitalInput__ = 1;
const uint IRTX__AnalogSerialInput__ = 0;
const uint COMMANDPROCESSORID__Parameter__ = 10;
const uint DEVICETYPE__Parameter__ = 11;
const uint MATRIXINDEX__Parameter__ = 12;
const uint COMMANDSTRING__Parameter__ = 13;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
