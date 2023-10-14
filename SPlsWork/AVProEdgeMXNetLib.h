namespace AVProEdgeMXNetLib.Enums;
        // class declarations
         class OsdMap;
         class ResolutionMap;
         class RotateMap;
         class DebugLevels;
     class OsdMap 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static AVProEdgeMXNetLib.Enums.OsdMap ON;
        static AVProEdgeMXNetLib.Enums.OsdMap OFF;

        // class properties
        SIGNED_INTEGER mxNetIndex;
        STRING index[];
        STRING name[];
    };

     class ResolutionMap 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static AVProEdgeMXNetLib.Enums.ResolutionMap _passthrough;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _1280x720_50;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _1280x720_60;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _1920x1080_24;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _1920x1080_50;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _1920x1080_60;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _3840x2160_30;
        static AVProEdgeMXNetLib.Enums.ResolutionMap _3840x2160_60;

        // class properties
        SIGNED_INTEGER mxNetIndex;
        STRING command[];
    };

     class RotateMap 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static AVProEdgeMXNetLib.Enums.RotateMap Rotate0;
        static AVProEdgeMXNetLib.Enums.RotateMap Rotate180;
        static AVProEdgeMXNetLib.Enums.RotateMap Rotate270;

        // class properties
        INTEGER mxNetIndex;
        STRING index[];
        STRING name[];
    };

    static class DebugLevels // enum
    {
        static SIGNED_LONG_INTEGER Unknown;
        static SIGNED_LONG_INTEGER Default;
        static SIGNED_LONG_INTEGER Warning;
        static SIGNED_LONG_INTEGER Error;
        static SIGNED_LONG_INTEGER Critical;
        static SIGNED_LONG_INTEGER Verbose;
    };

namespace AVProEdgeMXNetLib.Components.Abstract;
        // class declarations
         class BasicComponent;
         class EndpointComponent;
           class DigEventArgs;
           class MXNetResponse;
           class AnaEventArgs;
           class SerEventArgs;
     class BasicComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( BasicComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class EndpointComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( EndpointComponent sender, DigEventArgs args );
        EventHandler OnOnline ( EndpointComponent sender, DigEventArgs args );
        EventHandler OnScreen ( EndpointComponent sender, AnaEventArgs args );
        EventHandler OnHotPlug ( EndpointComponent sender, DigEventArgs args );
        EventHandler OnConnectionRating ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnResAndTiming ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnColorspace ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnBitdepth ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnHdr ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnHdcp ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnAudioFormat ( EndpointComponent sender, SerEventArgs args );
        EventHandler OnNetworkConnection ( EndpointComponent sender, SerEventArgs args );

        // class functions
        STRING_FUNCTION ToString ();
        FUNCTION Configure ( INTEGER ID , STRING DeviceID , INTEGER Index );
        FUNCTION SetReboot ();
        FUNCTION SetScreenOn ();
        FUNCTION SetScreenFlash ();
        FUNCTION SetScreenOff ();
        FUNCTION SetHotplugReset ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING MacAddress[];
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

namespace AVProEdgeMXNetLib.Components;
        // class declarations
         class VwLayoutComponent;
         class VwLayoutRecallComponent;
         class DestinationRouterComponent;
         class IrPortComponent;
         class ControlBoxComponent;
         class CecComponent;
         class DecoderComponent;
         class VwDecoderAssignComponent;
         class MultiDestinationRouterComponent;
         class SerialPortComponent;
         class EncoderComponent;
     class VwLayoutComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( VwLayoutComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER CommandID , INTEGER WallID , STRING WallName , INTEGER TotalRows , INTEGER TotalCols , INTEGER Stretch , SIGNED_LONG_INTEGER VisibleWidth , SIGNED_LONG_INTEGER VisibleHeight , SIGNED_LONG_INTEGER OuterWidth , SIGNED_LONG_INTEGER OuterHeight );
        FUNCTION TakeRoute ( INTEGER source );
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER WallID;
        STRING WallName[];
        INTEGER TotalRows;
        INTEGER TotalCols;
        INTEGER Stretch;
        SIGNED_LONG_INTEGER VisibleWidth;
        SIGNED_LONG_INTEGER VisibleHeight;
        SIGNED_LONG_INTEGER OuterWidth;
        SIGNED_LONG_INTEGER OuterHeight;
        STRING EncoderID[];
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class VwLayoutRecallComponent 
    {
        // class delegates

        // class events
        EventHandler OnLastRecalled ( VwLayoutRecallComponent sender, SerEventArgs args );
        EventHandler OnInitialize ( VwLayoutRecallComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID , STRING WallName , INTEGER LayoutType );
        FUNCTION RecallLayout ( STRING command );
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class DestinationRouterComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( DestinationRouterComponent sender, DigEventArgs args );
        EventHandler OnSourceVideo ( DestinationRouterComponent sender, AnaEventArgs args );
        EventHandler OnSourceAudio ( DestinationRouterComponent sender, AnaEventArgs args );
        EventHandler OnSourceUsb ( DestinationRouterComponent sender, AnaEventArgs args );
        EventHandler OnSourceInfrared ( DestinationRouterComponent sender, AnaEventArgs args );
        EventHandler OnSourceSerial ( DestinationRouterComponent sender, AnaEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID , INTEGER Index , STRING Groups );
        FUNCTION SetRoute ( INTEGER source );
        FUNCTION TakeRoute ();
        FUNCTION SetEnableVideo ( INTEGER state );
        FUNCTION SetEnableAudio ( INTEGER state );
        FUNCTION SetEnableUsb ( INTEGER state );
        FUNCTION SetEnableInfrared ( INTEGER state );
        FUNCTION SetEnableSerial ( INTEGER state );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
        STRING DecoderID[];
        STRING EnableCmd[];
    };

     class IrPortComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( IrPortComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID , INTEGER EndpointType , INTEGER MatrixIndex );
        FUNCTION SendCommand ( STRING command );
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class ControlBoxComponent 
    {
        // class delegates

        // class events
        EventHandler OnIPAddress ( ControlBoxComponent sender, SerEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID );
        FUNCTION Passthru ( STRING cmd );
        FUNCTION RebootController ();
        FUNCTION RebootSystem ();
        FUNCTION AllScreenOn ();
        FUNCTION AllScreenFlash ();
        FUNCTION AllScreenOff ();
        FUNCTION AllOsdOn ();
        FUNCTION AllOsdOff ();
        FUNCTION ProcessIPAddress ( STRING ip );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class CecComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( CecComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID , INTEGER MatrixIndex );
        FUNCTION CecOn ();
        FUNCTION CecOff ();
        FUNCTION SendCommand ( STRING command );
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class DecoderComponent 
    {
        // class delegates

        // class events
        EventHandler OnVideoWallCount ( DecoderComponent sender, AnaEventArgs args );
        EventHandler OnOsdMode ( DecoderComponent sender, AnaEventArgs args );
        EventHandler OnResolution ( DecoderComponent sender, AnaEventArgs args );
        EventHandler OnInitialize ( DecoderComponent sender, DigEventArgs args );
        EventHandler OnOnline ( DecoderComponent sender, DigEventArgs args );
        EventHandler OnScreen ( DecoderComponent sender, AnaEventArgs args );
        EventHandler OnHotPlug ( DecoderComponent sender, DigEventArgs args );
        EventHandler OnConnectionRating ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnResAndTiming ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnColorspace ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnBitdepth ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnHdr ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnHdcp ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnAudioFormat ( DecoderComponent sender, SerEventArgs args );
        EventHandler OnNetworkConnection ( DecoderComponent sender, SerEventArgs args );

        // class functions
        FUNCTION SetOsdOn ();
        FUNCTION SetOsdOff ();
        FUNCTION SetResolution ( SIGNED_INTEGER value );
        FUNCTION RefreshVideoWallCount ();
        STRING_FUNCTION ToString ();
        FUNCTION Configure ( INTEGER ID , STRING DeviceID , INTEGER Index );
        FUNCTION SetReboot ();
        FUNCTION SetScreenOn ();
        FUNCTION SetScreenFlash ();
        FUNCTION SetScreenOff ();
        FUNCTION SetHotplugReset ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING MacAddress[];
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class VwDecoderAssignComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( VwDecoderAssignComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER CommandID , INTEGER WallID , INTEGER Index , INTEGER Column , INTEGER Row , INTEGER Rotate );
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER WallID;
        INTEGER Index;
        STRING UserID[];
        INTEGER Column;
        INTEGER Row;
        STRING Rotate[];
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class MultiDestinationRouterComponent 
    {
        // class delegates

        // class events
        EventHandler OnInitialize ( MultiDestinationRouterComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID , INTEGER Group );
        FUNCTION SetRoute ( INTEGER source );
        FUNCTION TakeMultiRoute ();
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class SerialPortComponent 
    {
        // class delegates

        // class events
        EventHandler OnRX ( SerialPortComponent sender, SerEventArgs args );
        EventHandler OnInitialize ( SerialPortComponent sender, DigEventArgs args );

        // class functions
        FUNCTION Configure ( INTEGER ID , INTEGER EndpointType , INTEGER MatrixIndex , INTEGER baudRate , INTEGER dataBit , INTEGER stopBit , INTEGER dataParity );
        FUNCTION SetCrestronCommSpec ( STRING spec );
        FUNCTION SendCommand ( STRING command );
        FUNCTION Process ( MXNetResponse response );
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING MacAddress[];
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

     class EncoderComponent 
    {
        // class delegates

        // class events
        EventHandler OnVolumeLevel ( EncoderComponent sender, AnaEventArgs args );
        EventHandler OnVolumeMute ( EncoderComponent sender, DigEventArgs args );
        EventHandler OnEdid ( EncoderComponent sender, AnaEventArgs args );
        EventHandler OnInitialize ( EncoderComponent sender, DigEventArgs args );
        EventHandler OnOnline ( EncoderComponent sender, DigEventArgs args );
        EventHandler OnScreen ( EncoderComponent sender, AnaEventArgs args );
        EventHandler OnHotPlug ( EncoderComponent sender, DigEventArgs args );
        EventHandler OnConnectionRating ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnResAndTiming ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnColorspace ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnBitdepth ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnHdr ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnHdcp ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnAudioFormat ( EncoderComponent sender, SerEventArgs args );
        EventHandler OnNetworkConnection ( EncoderComponent sender, SerEventArgs args );

        // class functions
        FUNCTION SetEdid ( SIGNED_INTEGER value );
        FUNCTION SetVolumeInc ();
        FUNCTION SetVolumeDec ();
        FUNCTION SetVolumeStop ();
        FUNCTION SetVolumeDiscrete ( INTEGER value );
        FUNCTION SetMuteOn ();
        FUNCTION SetMuteOff ();
        FUNCTION SetMuteTog ();
        FUNCTION SetAudioSource ( INTEGER value );
        STRING_FUNCTION ToString ();
        FUNCTION Configure ( INTEGER ID , STRING DeviceID , INTEGER Index );
        FUNCTION SetReboot ();
        FUNCTION SetScreenOn ();
        FUNCTION SetScreenFlash ();
        FUNCTION SetScreenOff ();
        FUNCTION SetHotplugReset ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING ChAssignment[];
        STRING MacAddress[];
        INTEGER CommandProcessorId;
        INTEGER Id;
    };

namespace AVProEdgeMXNetLib.Models;
        // class declarations
         class MXNetResponse;
         class LightMap;
         class MXNetRequest;
         class AudioInput;
     class MXNetResponse 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Cmd[];
        SIGNED_LONG_INTEGER Code;
        STRING Error[];
        STRING Id[];
        STRING Mac[];
        STRING Source[];
    };

     class LightMap 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static AVProEdgeMXNetLib.Models.LightMap ON;
        static AVProEdgeMXNetLib.Models.LightMap FLASH;
        static AVProEdgeMXNetLib.Models.LightMap OFF;

        // class properties
        SIGNED_INTEGER mxNetIndex;
        STRING index[];
        STRING name[];
    };

    static class AudioInput // enum
    {
        static SIGNED_LONG_INTEGER Unknown;
        static SIGNED_LONG_INTEGER HDMI;
        static SIGNED_LONG_INTEGER Analog;
        static SIGNED_LONG_INTEGER Auto;
    };

namespace AVProEdgeMXNetLib.Models.Endpoints;
        // class declarations
         class EndpointDeviceStatus;
         class EndpointDeviceStatusDetails;
         class EndpointDeviceInfo;
         class VideoDetails;
     class EndpointDeviceStatus 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION set_Item ( STRING key , EndpointDeviceStatusDetails value );
        FUNCTION Add ( STRING key , EndpointDeviceStatusDetails value );
        FUNCTION Clear ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER Count;
    };

     class EndpointDeviceStatusDetails 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Chroma[];
        STRING Version[];
        STRING Bufold[];
        STRING DType[];
        STRING BufTmp[];
        STRING ColorDepth[];
        STRING Speed[];
        STRING Id[];
        STRING Video[];
        STRING Audio[];
        STRING Ch[];
        STRING SwitchIp[];
        STRING SwitchPort[];
        STRING Hdcp[];
        STRING Buf[];
        STRING Ip[];
        STRING Hdr[];
        STRING Profile[];
        STRING Hdp[];
        STRING Edid[];
        STRING Hpd[];
        STRING Timing[];
        STRING AvInfo[];
        STRING ConnectedName[];
        STRING AccessOnU[];
        STRING AccessOnA[];
        STRING AccessOnC[];
        STRING AccessOnR[];
        STRING AccessOnV[];
        STRING AccessOnS[];
        STRING AccessOnP[];
    };

     class EndpointDeviceInfo 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Chipset[];
        STRING Version[];
        STRING Ip[];
        STRING Subnet[];
        STRING Gateway[];
        STRING State[];
        STRING Id[];
        STRING Mac[];
        STRING Volume[];
        STRING IpMode[];
        STRING Rs232Mode[];
        STRING Ch[];
        STRING Switchport[];
        STRING DType[];
        STRING Edid[];
        STRING Pattern[];
        STRING Blackout[];
        STRING Stretch[];
        STRING Rotate[];
        STRING HdrMode[];
        STRING VMode[];
        STRING ChP[];
        STRING ChU[];
        STRING ChV[];
        STRING ChA[];
        STRING ChR[];
        STRING ChC[];
        STRING ChS[];
        VideoDetails Video;
        STRING Stream[];
    };

     class VideoDetails 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING FPS[];
        STRING Height[];
        STRING Width[];
    };

namespace AVProEdgeMXNetLib.Utilities;
        // class declarations
         class TimerUtil;
         class VolumeUtil;
         class Ramp;
         class ProtocolRequestUtil;
         class CrestronCommSpec;
         class eBaudRate;
         class eDataBits;
         class eStopBits;
         class eParity;
         class eHandshaking;
         class ePorts;
         class eFormat;
     class TimerUtil 
    {
        // class delegates

        // class events
        EventHandler OnElapsedTime ( TimerUtil sender, EventArgs e );

        // class functions
        FUNCTION Start ();
        FUNCTION Stop ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER DueTime;
    };

    static class Ramp // enum
    {
        static SIGNED_LONG_INTEGER Stop;
        static SIGNED_LONG_INTEGER Inc;
        static SIGNED_LONG_INTEGER Dec;
    };

     class ProtocolRequestUtil 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static STRING DELIMITER[];

        // class properties
    };

     class CrestronCommSpec 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        eBaudRate BaudRate;
        eDataBits DataBits;
        eStopBits StopBits;
        eParity Parity;
        eHandshaking Handshaking;
        ePorts Ports;
        eFormat Format;
    };

    static class eBaudRate // enum
    {
        static SIGNED_LONG_INTEGER Baud_300;
        static SIGNED_LONG_INTEGER Baud_600;
        static SIGNED_LONG_INTEGER Baud_1200;
        static SIGNED_LONG_INTEGER Baud_2400;
        static SIGNED_LONG_INTEGER Baud_4800;
        static SIGNED_LONG_INTEGER Baud_9600;
        static SIGNED_LONG_INTEGER Baud_19200;
        static SIGNED_LONG_INTEGER Baud_38400;
        static SIGNED_LONG_INTEGER Baud_1800;
        static SIGNED_LONG_INTEGER Baud_3600;
        static SIGNED_LONG_INTEGER Baud_7200;
        static SIGNED_LONG_INTEGER Baud_14400;
        static SIGNED_LONG_INTEGER Baud_28800;
        static SIGNED_LONG_INTEGER Baud_57600;
        static SIGNED_LONG_INTEGER Baud_115200;
    };

    static class eDataBits // enum
    {
        static SIGNED_LONG_INTEGER Bits_7;
        static SIGNED_LONG_INTEGER Bits_8;
    };

    static class eStopBits // enum
    {
        static SIGNED_LONG_INTEGER Bits_1;
        static SIGNED_LONG_INTEGER Bits_2;
    };

    static class eParity // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER Even;
        static SIGNED_LONG_INTEGER Odd;
    };

    static class eHandshaking // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER Hardware;
        static SIGNED_LONG_INTEGER Software;
    };

    static class ePorts // enum
    {
        static SIGNED_LONG_INTEGER Unknown;
        static SIGNED_LONG_INTEGER Port_A;
        static SIGNED_LONG_INTEGER Port_B;
        static SIGNED_LONG_INTEGER Port_C;
        static SIGNED_LONG_INTEGER Port_D;
        static SIGNED_LONG_INTEGER Port_E;
        static SIGNED_LONG_INTEGER Port_F;
    };

    static class eFormat // enum
    {
        static SIGNED_LONG_INTEGER RS232;
        static SIGNED_LONG_INTEGER RS422;
        static SIGNED_LONG_INTEGER RS485;
    };

namespace AVProEdgeMXNetLib;
        // class declarations
         class CommandProcessor;
         class ExtendedQueuePriorities;
     class CommandProcessor 
    {
        // class delegates

        // class events
        EventHandler OnInitializationChange ( CommandProcessor sender, AnaEventArgs args );
        EventHandler OnCommunicationChange ( CommandProcessor sender, AnaEventArgs args );
        EventHandler OnDebugMessage ( CommandProcessor sender, SerEventArgs args );
        EventHandler OnReadyState ( CommandProcessor sender, EventArgs e );

        // class functions
        FUNCTION Configure ( INTEGER Id , STRING IPAddress , INTEGER PollTimeSec );
        FUNCTION Connect ();
        FUNCTION Disconnect ();
        FUNCTION DebugLevel ( INTEGER Level );
        FUNCTION Reinitialize ();
        FUNCTION SetIPAddress ( STRING IPAddress );
        FUNCTION Message ( DebugLevels level , STRING msg );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING IPAddress[];
    };

    static class ExtendedQueuePriorities // enum
    {
        static SIGNED_LONG_INTEGER Cmd;
        static SIGNED_LONG_INTEGER Query;
        static SIGNED_LONG_INTEGER Serial;
    };

namespace AVProEdgeMXNetLib.EventArguments;
        // class declarations
         class AnaEventArgs;
         class SerEventArgs;
         class DigEventArgs;
     class AnaEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Payload;
    };

     class SerEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Payload[];
    };

     class DigEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Payload;
    };

namespace AVProEdgeMXNetLib.Models.Layouts;
        // class declarations
         class VwidLayouts;
         class LayoutDetails;
         class VwMosaics;
         class MosaicDetails;
         class ScreenDetails;
         class DisplayDetails;
         class VwidLayoutsList;
         class VwMosaicsList;
     class VwidLayouts 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class LayoutDetails 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class VwMosaics 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class MosaicDetails 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ScreenDetails 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Rotation[];
        STRING BezelRight[];
        STRING TopOffset[];
        STRING DisplayHeight[];
        STRING CaptureWidth[];
        STRING BezelLeft[];
        STRING CaptureHeight[];
        STRING Client[];
        STRING LeftOffset[];
        STRING Host[];
        STRING CaptureTopOffset[];
        STRING BezelTop[];
        STRING CaptureLeftOffset[];
        STRING Manufacturer[];
        STRING BezelBottom[];
        STRING DisplayWidth[];
        STRING Model[];
    };

     class DisplayDetails 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Rotation[];
        STRING Manufacturer[];
        STRING Model[];
    };

     class VwidLayoutsList 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION set_Item ( STRING key , VwidLayouts value );
        FUNCTION Add ( STRING key , VwidLayouts value );
        FUNCTION Clear ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER Count;
    };

     class VwMosaicsList 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION set_Item ( STRING key , VwMosaics value );
        FUNCTION Add ( STRING key , VwMosaics value );
        FUNCTION Clear ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER Count;
    };

namespace AVProEdgeMXNetLib.JsonSupport;
        // class declarations
         class MXNetJsonConverter;
     class MXNetJsonConverter 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace AVProEdgeMXNetLib.Interfaces;
        // class declarations
         class EndpointType;
    static class EndpointType // enum
    {
        static SIGNED_LONG_INTEGER Unknown;
        static SIGNED_LONG_INTEGER Encoder;
        static SIGNED_LONG_INTEGER Decoder;
    };

namespace AVProEdgeMXNetLib.Enums.Attributes;
        // class declarations
         class MXNetProtocolAttribute;

