using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models.Cfg
{
    public class Configuration
    {
        public enum ConfFolder
        {
            IDENTITY,
            GENERAL,
            LTE,
            NETWORK,
            QOS,
            RCS,
            SECURITY,
            SESSIONS,
            MEDIA,
            NATT,
            CONTACTS,
            XCAP
        }

        public enum ConfEntry
        {
            TIMEOUT,
            PASSWORD,
            DISPLAY_NAME,
            IMPI,
            IMPU,
            PRIVACY,
            REMEMBER_PASSWORD,
            REALM,
            FULL_SCREEN_VIDEO,
            FFC,
            AUDIO_PLAY_LEVEL,
            AUDIO_VOLUME,
            ENUM_DOMAIN,
            AUTO_START,
            EARLY_IMS,
            IP_VERSION,
            PCSCF_DISCOVERY_DNS,
            PCSCF_DISCOVERY_DHCP,
            PCSCF_HOST,
            PCSCF_PORT,
            SIGCOMP,
            THREE_3G,
            TRANSPORT,
            WIFI,
            LOCAL_IP,
            LOCAL_PORT,
            PRECOND_STRENGTH,
            PRECOND_TYPE,
            BANDWIDTH,
            PREF_VIDEO_SIZE,
            SESSION_TIMERS_REFRESHER,
            SESSION_TIMERS_TIMEOUT,
            SIP_SESSIONS_TIMEOUT,
            SESSION_TIMERS,
            USE_ZERO_VIDEO_ARTIFACTS,
            VIDEO_FPS,
            USE_ECHO_SUPP,
            USE_NOISE_SUPP,
            USE_AGC,
            USE_VAD,
            USE_RTCP,
            USE_RTCPMUX,
            ECHO_TAIL,
            ECHO_SKEW,
            JB_MAX_LATERATE,
            AVATAR_PATH,
            BINARY_SMS,
            CONF_FACT,
            FREE_TEXT,
            HACK_SMS,
            HOME_PAGE,
            HYPERAVAILABILITY_TIMEOUT,
            IMDN,
            ISCOMOPING,
            MSRP_FAILURE,
            MSRP_SUCCESS,
            MWI,
            OMAFDR,
            PARTIAL_PUB,
            PRESENCE_PUB,
            PRESENCE_SUB,
            RLS,
            SMSC,
            STATUS,
            TLS_CA_FILE,
            TLS_PRIV_KEY_FILE,
            TLS_PUB_KEY_FILE,
            TLS_SEC_AGREE,
            SRTP_MODE,
            SRTP_TYPE,
            IMSAKA_AMF,
            IMSAKA_OPID,
            IPSEC_SEC_AGREE,
            IPSEC_ALGO,
            IPSEC_EALGO,
            IPSEC_MODE,
            IPSEC_PROTO,
            CODECS,
            PROFILE,
            HACK_AOR,
            HACK_AOR_TIMEOUT,
            USE_STUN_FOR_SIP,
            USE_STUN_FOR_ICE,
            USE_TURN_FOR_ICE,
            USE_ICE,
            STUN_DISCO,
            STUN_SERVER,
            STUN_PORT,
            STUN_USERNAME,
            STUN_PASSWORD,
            USE_SYMETRIC_RTP,
            CONTACT_STORAGE,
            REMOTE_CONTACT_TYPE,
            XCAP_ROOT,
            XCAP_ROOT_IP,
            XCAP_TIMEOUT,
            XCAP_XUI,
            XCAP_USERNAME,
            XCAP_PASSWORD
        }

        private const string QOS_STRENGTH_NONE = "None";

        private const string QOS_STRENGTH_MANDATORY = "Mandatory";

        private const string QOS_STRENGTH_OPTIONAL = "Optional";

        private const string QOS_STRENGTH_FAILURE = "Failure";

        private const string QOS_STRENGTH_UNKNOWN = "Unknown";

        private const string QOS_TYPE_NONE = "None";

        private const string QOS_TYPE_SEGMENTED = "Segmented";

        private const string QOS_TYPE_E2E = "End-to-End";

        private const string QOS_BANDWIDTH_LOW = "Low";

        private const string QOS_BANDWIDTH_MEDIUM = "Medium";

        private const string QOS_BANDWIDTH_HIGH = "High";

        public static string PCSCF_DISCOVERY_NONE = "None";

        public static string PCSCF_DISCOVERY_DNS = "DNS NAPTR+SRV";

        public static string DEFAULT_IDENTITY_DISPLAY_NAME = "John Doe";

        public static string DEFAULT_IDENTITY_IMPI = "johndoe@test.com";

        public static string DEFAULT_IDENTITY_IMPU = "sip:johndoe@test.com";

        public static string DEFAULT_IDENTITY_PASSWORD = string.Empty;

        public static string DEFAULT_IDENTITY_PRIVACY = "none";

        public static bool DEFAULT_NETWORK_EARLY_IMS = false;

        public static bool DEFAULT_NETWORK_PCSCF_DISCOVERY_DNS = false;

        public static bool DEFAULT_NETWORK_PCSCF_DISCOVERY_DHCP = false;

        public static string DEFAULT_NETWORK_PCSCF_HOST = "127.0.0.1";

        public static int DEFAULT_NETWORK_PCSCF_PORT = 5060;

        public static string DEFAULT_NETWORK_REALM = "test.com";

        public static bool DEFAULT_NETWORK_SIGCOMP = false;

        public static string DEFAULT_NETWORK_TRANSPORT = "UDP";

        public static string DEFAULT_NETWORK_IP_VERSION = "ipv4";

        public static bool DEFAULT_NETWORK_WIFI = true;

        public static bool DEFAULT_NETWORK_3G = false;

        public static string DEFAULT_NETWORK_LOCAL_IP = string.Empty;

        public static int DEFAULT_NETWORK_LOCAL_PORT = 0;

        public static bool DEFAULT_GENERAL_FULL_SCREEN_VIDEO = true;

        public static bool DEFAULT_GENERAL_FFC = true;

        public static bool DEFAULT_GENERAL_AUTOSTART = true;

        public static float DEFAULT_GENERAL_AUDIO_PLAY_LEVEL = 0.25f;

        public static string DEFAULT_GENERAL_ENUM_DOMAIN = "e164.org";

        public static int DEFAULT_GENERAL_AUDIO_VOLUME = 100;

        public static string DEFAULT_RCS_AVATAR_PATH = "";

        public static bool DEFAULT_RCS_BINARY_SMS = false;

        public static string DEFAULT_RCS_CONF_FACT = "sip:Conference-Factory@test.com";

        public static string DEFAULT_RCS_FREE_TEXT = "Hello world";

        public static bool DEFAULT_RCS_MSRP_FAILURE = true;

        public static bool DEFAULT_RCS_MSRP_SUCCESS = false;

        public static bool DEFAULT_RCS_MWI = false;

        public static bool DEFAULT_RCS_OMAFDR = false;

        public static bool DEFAULT_RCS_PARTIAL_PUB = false;

        public static bool DEFAULT_RCS_PRESENCE_SUB = true;

        public static bool DEFAULT_RCS_PRESENCE_PUB = true;

        public static bool DEFAULT_RCS_RLS = true;

        public static string DEFAULT_RCS_SMSC = "sip:+331000000000@test.com";

        public static string DEFAULT_RCS_HOME_PAGE = "http://www.cetc7.com";

        public static int DEFAULT_RCS_HYPERAVAILABILITY_TIMEOUT = 1;

        public static bool DEFAULT_RCS_IMDN = false;

        public static bool DEFAULT_RCS_ISCOMOPING = true;

        public static string DEFAULT_QOS_BANDWIDTH = tmedia_bandwidth_level_t.tmedia_bl_medium.ToString();

        public static string DEFAULT_QOS_PREF_VIDEO_SIZE = tmedia_pref_video_size_t.tmedia_pref_video_size_cif.ToString();

        public static string DEFAULT_QOS_PRECOND_STRENGTH = tmedia_qos_strength_t.tmedia_qos_strength_none.ToString();

        public static string DEFAULT_QOS_PRECOND_TYPE = tmedia_qos_stype_t.tmedia_qos_stype_none.ToString();

        public static string DEFAULT_QOS_SESSION_TIMERS_REFRESHER = "none";

        public static int DEFAULT_QOS_SIP_SESSIONS_TIMEOUT = 600000;

        public static int DEFAULT_QOS_VIDEO_FPS = 20;

        public static int DEFAULT_QOS_SESSION_TIMERS_TIMEOUT = 3600;

        public static bool DEFAULT_QOS_SESSION_TIMERS = false;

        public static bool DEFAULT_QOS_USE_ZERO_VIDEO_ARTIFACTS = false;

        public static bool DEFAULT_QOS_USE_ECHO_SUPP = true;

        public static int DEFAULT_QOS_ECHO_TAIL = 100;

        public static int DEFAULT_QOS_ECHO_SKEW = 0;

        public static bool DEFAULT_QOS_USE_NOISE_SUPP = true;

        public static bool DEFAULT_QOS_USE_AGC = false;

        public static bool DEFAULT_QOS_USE_VAD = false;

        public static bool DEFAULT_QOS_USE_RTCP = true;

        public static bool DEFAULT_QOS_USE_RTCPMUX = true;

        public static int DEFAULT_QOS_JB_MAX_LATERATE = 1;

        public static string DEFAULT_TLS_CA_FILE = string.Empty;

        public static string DEFAULT_TLS_PRIV_KEY_FILE = string.Empty;

        public static string DEFAULT_TLS_PUB_KEY_FILE = string.Empty;

        public static bool DEFAULT_TLS_SEC_AGREE = false;

        public static string DEFAULT_IMSAKA_AMF = "0x0000";

        public static string DEFAULT_IMSAKA_OPID = "0x00000000000000000000000000000000";

        public static string DEFAULT_SECURITY_SRTP_MODE = tmedia_srtp_mode_t.tmedia_srtp_mode_none.ToString();

        public static string DEFAULT_SECURITY_SRTP_TYPE = tmedia_srtp_type_t.tmedia_srtp_type_sdes.ToString();

        public static string DEFAULT_SECURITY_IPSEC_ALGO = "hmac-md5-96";

        public static string DEFAULT_SECURITY_IPSEC_EALGO = "null";

        public static string DEFAULT_SECURITY_IPSEC_MODE = "trans";

        public static string DEFAULT_SECURITY_IPSEC_PROTO = "ah";

        public static bool DEFAULT_SECURITY_IPSEC_SEC_AGREE = false;

        public static int DEFAULT_NATT_HACK_AOR_TIMEOUT = 2000;

        public static bool DEFAULT_NATT_HACK_AOR = false;

        public static bool DEFAULT_NATT_USE_STUN_FOR_SIP = false;

        public static bool DEFAULT_NATT_USE_STUN_FOR_ICE = true;

        public static bool DEFAULT_NATT_USE_TURN_FOR_ICE = false;

        public static bool DEFAULT_NATT_USE_ICE = false;

        public static bool DEFAULT_NATT_USE_SYMETRIC_RTP = false;

        public static bool DEFAULT_NATT_STUN_DISCO = false;

        public static string DEFAULT_NATT_STUN_SERVER = "numb.viagenie.ca";

        public static int DEFAULT_NATT_STUN_PORT = 3478;

        public static string DEFAULT_NATT_STUN_USERNAME = string.Empty;

        public static string DEFAULT_NATT_STUN_PASSWORD = string.Empty;

        public static string DEFAULT_CONTACT_STORAGE_TYPE = "Local";

        public static string DEFAULT_REMOTE_CONTACT_TYPE = "XCAP";

        public static string DEFAULT_XCAP_ROOT = "http://doubango.org:8080/services";

        public static string DEFAULT_XUI = "sip:johndoe@test.com";

        public static int DEFAULT_XCAP_TIMEOUT = 6000;

        public static int DEFAULT_MEDIA_CODECS = 51773808;

        public static string DEFAULT_MEDIA_PROFILE = tmedia_profile_t.tmedia_profile_default.ToString();

        public static string QoSStrengthToString(tmedia_qos_strength_t strength)
        {
            string result;
            switch (strength)
            {
                case tmedia_qos_strength_t.tmedia_qos_strength_none:
                    result = "None";
                    return result;
                case tmedia_qos_strength_t.tmedia_qos_strength_failure:
                    result = "Failure";
                    return result;
                case tmedia_qos_strength_t.tmedia_qos_strength_optional:
                    result = "Optional";
                    return result;
                case tmedia_qos_strength_t.tmedia_qos_strength_mandatory:
                    result = "Mandatory";
                    return result;
            }
            result = "Unknown";
            return result;
        }

        public static tmedia_qos_strength_t QoSStrengthFromString(string strength)
        {
            tmedia_qos_strength_t result;
            if ("None".Equals(strength))
            {
                result = tmedia_qos_strength_t.tmedia_qos_strength_none;
            }
            else if ("Mandatory".Equals(strength))
            {
                result = tmedia_qos_strength_t.tmedia_qos_strength_mandatory;
            }
            else if ("Optional".Equals(strength))
            {
                result = tmedia_qos_strength_t.tmedia_qos_strength_optional;
            }
            else if ("Failure".Equals(strength))
            {
                result = tmedia_qos_strength_t.tmedia_qos_strength_failure;
            }
            else
            {
                result = tmedia_qos_strength_t.tmedia_qos_strength_unknown;
            }
            return result;
        }

        public static string QoSTypeToString(tmedia_qos_stype_t type)
        {
            string result;
            switch (type)
            {
                case tmedia_qos_stype_t.tmedia_qos_stype_segmented:
                    result = "Segmented";
                    return result;
                case tmedia_qos_stype_t.tmedia_qos_stype_e2e:
                    result = "End-to-End";
                    return result;
            }
            result = "None";
            return result;
        }

        public static tmedia_qos_stype_t QoSTypeFromString(string type)
        {
            tmedia_qos_stype_t result;
            if ("End-to-End".Equals(type))
            {
                result = tmedia_qos_stype_t.tmedia_qos_stype_e2e;
            }
            else if ("Segmented".Equals(type))
            {
                result = tmedia_qos_stype_t.tmedia_qos_stype_segmented;
            }
            else
            {
                result = tmedia_qos_stype_t.tmedia_qos_stype_none;
            }
            return result;
        }

        public static string QoSBandwidthToString(tmedia_bandwidth_level_t bl)
        {
            switch (bl)
            {
                case tmedia_bandwidth_level_t.tmedia_bl_low:
                    {
                        string result = "Low";
                        return result;
                    }
                case tmedia_bandwidth_level_t.tmedia_bl_medium:
                    {
                        string result = "Medium";
                        return result;
                    }
                case tmedia_bandwidth_level_t.tmedia_bl_hight:
                    {
                    IL_17:
                        string result = "High";
                        return result;
                    }
            }

            return "";
            //goto IL_17;
        }

        public static tmedia_bandwidth_level_t QoSBandwidthFromString(string bl)
        {
            tmedia_bandwidth_level_t result;
            if ("Low".Equals(bl))
            {
                result = tmedia_bandwidth_level_t.tmedia_bl_low;
            }
            else if ("Medium".Equals(bl))
            {
                result = tmedia_bandwidth_level_t.tmedia_bl_medium;
            }
            else
            {
                result = tmedia_bandwidth_level_t.tmedia_bl_hight;
            }
            return result;
        }

        public static int QoSMotionRankFromBandwidth(tmedia_bandwidth_level_t bw)
        {
            int result;
            switch (bw)
            {
                case tmedia_bandwidth_level_t.tmedia_bl_low:
                    result = 1;
                    return result;
                case tmedia_bandwidth_level_t.tmedia_bl_hight:
                case tmedia_bandwidth_level_t.tmedia_bl_unrestricted:
                    result = 4;
                    return result;
            }
            result = 2;
            return result;
        }
    }
}
