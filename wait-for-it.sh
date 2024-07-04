#!/usr/bin/env bash
# Use this script to test if a given TCP host/port are available

TIMEOUT=15
STRICT=0
HOST=""
PORT=""
WAIT_FOR_IT=0
WAIT_INTERVAL=1
CMD=""
QUIET=0

usage()
{
    echo "Usage: $0 host:port [-t timeout] [-- command args]"
    echo " -h HOST | --host=HOST       Host or IP under test"
    echo " -p PORT | --port=PORT       TCP port under test"
    echo " -t TIMEOUT | --timeout=TIMEOUT"
    echo "                             Timeout in seconds, zero for no timeout"
    echo " -s | --strict               Only execute subcommand if the test succeeds"
    echo " -q | --quiet                Don't output any status messages"
    echo " -- COMMAND ARGS             Execute command with args after the test finishes"
    exit 1
}

wait_for()
{
    echo "Waiting for $HOST:$PORT..."
    for i in `seq $TIMEOUT` ; do
        nc -z $HOST $PORT > /dev/null 2>&1
        result=$?
        if [ $result -eq 0 ] ; then
            if [ $QUIET -ne 1 ] ; then echo "Success! $HOST:$PORT is available." ; fi
            return 0
        fi
        sleep 1
    done
    echo "Timed out after $TIMEOUT seconds waiting for $HOST:$PORT."
    return 1
}

while [[ $# -gt 0 ]]
do
    case "$1" in
        *:* )
        HOSTPORT=(${1//:/ })
        HOST=${HOSTPORT[0]}
        PORT=${HOSTPORT[1]}
        shift 1
        ;;
        -h)
        HOST="$2"
        if [[ $HOST == "" ]]; then break; fi
        shift 2
        ;;
        --host=*)
        HOST="${1#*=}"
        shift 1
        ;;
        -p)
        PORT="$2"
        if [[ $PORT == "" ]]; then break; fi
        shift 2
        ;;
        --port=*)
        PORT="${1#*=}"
        shift 1
        ;;
        -t)
        TIMEOUT="$2"
        if [[ $TIMEOUT == "" ]]; then break; fi
        shift 2
        ;;
        --timeout=*)
        TIMEOUT="${1#*=}"
        shift 1
        ;;
        -s | --strict)
        STRICT=1
        shift 1
        ;;
        -q | --quiet)
        QUIET=1
        shift 1
        ;;
        --)
        shift
        CMD="$@"
        break
        ;;
        --help)
        usage
        ;;
        *)
        echo "Unknown argument: $1"
        usage
        ;;
    esac
done

if [[ "$HOST" == "" || "$PORT" == "" ]]; then
    echo "Error: you need to provide a host and port to test."
    usage
fi

wait_for
result=$?

if [[ $CMD != "" ]]; then
    if [[ $result -ne 0 && $STRICT -eq 1 ]]; then
        echo "Strict mode, refusing to execute subprocess"
        exit $result
    fi
    exec $CMD
else
    exit $result
fi
