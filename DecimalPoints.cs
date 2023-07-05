string DPToString(double val, int dp) {
    string processedBody;
    string body = val.ToString(Constants.NO_SCI_FORMAT);
    int bodyDotIndex = body.Length;
    for(int i = 0; i < body.Length; i++) {
        if(body[i] == '.') {
            bodyDotIndex = i;
            break;
        }
    }
    if(dp > 0) {
        int originalDP = Math.Max(body.Length - bodyDotIndex - 1, 0);

        if(originalDP < dp) {
            processedBody = body + (body.Length == bodyDotIndex ? "." : "");
            for(int i = dp - originalDP; i > 0; i--) {
                processedBody += "0";
            }
        }
        else if(originalDP == dp) {
            processedBody = body;
        }
        else {  // originalDP > precision
            processedBody = val.ToString("0." + new string('#', dp));
        }
    }
    else if(dp == 0) {
        processedBody = val.ToString("#");
    }
    else {  // precision < 0
        if(1 - dp > bodyDotIndex) {
            processedBody = "0";
        }
        else {
            processedBody = val.ToString("#").Substring(0, bodyDotIndex + dp);
            for(int i = 0; i < -dp; i++) {
                processedBody += "0";
            }
        }
    }
    return processedBody;
}