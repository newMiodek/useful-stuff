string SFToString(double val, int sf) {
    string processedVal = "";
    string valStr = val.ToString(Constants.NO_SCI_FORMAT);
    bool hasDot = false;
    for(int i = 0; i < valStr.Length; i++) {
        if(valStr[i] == '.') {
            hasDot = true;
            break;
        }
    }
    if(hasDot) {
        if(valStr.StartsWith("0.")) {   // This is wrong because 0.(00)123
            int originalDP = valStr.Length - 2;
            if(originalDP == sf) {
                processedVal = valStr;
            }
            else if(originalDP < sf) {
                while(valStr.Length - 2 < sf) valStr += "0";
            }
            else {  // originalDP > sf
                processedVal = valStr.Substring(0, sf + 2);
            }
        }
        else {  // Doesn't start with "0."
            int dotIndex = valStr.Length;
            for(int i = 0; i < valStr.Length; i++) {
                if(valStr[i] == '.') {
                    dotIndex = i;
                    break;
                }
            }
            if(dotIndex >= sf) {
                double shifter = 1.0;
                for(int i = 0; i < dotIndex - sf; i++) shifter *= 10.0;
                string shiftedVal = (val / shifter).ToString("#");
                if(shiftedVal.Length == 0) shiftedVal = "0";
                processedVal = (int.Parse(shiftedVal) * ((int)shifter)).ToString();
            }
            else {  // dotIndex < sf
                double shifter = 1.0;
                for(int i = 0; i < sf - dotIndex; i++) shifter *= 10.0;
                string shiftedVal = (val * shifter).ToString("#");
                if(shiftedVal.Length == 0) shiftedVal = "0";
                processedVal = shiftedVal.Insert(dotIndex, ".");
            }
        }
    }
    else {  // !hasDot
        if(valStr.Length == sf) {
            processedVal = valStr;
        }
        else if(valStr.Length > sf) {
            double shifter = 1.0;
            for(int i = 0; i < valStr.Length - sf; i++) shifter *= 10.0;
            string shiftedVal = (val / shifter).ToString("#");
            if(shiftedVal.Length == 0) shiftedVal = "0";
            processedVal = (int.Parse(shiftedVal) * ((int)shifter)).ToString();
        }
        else {  // valStr.Length < sf
            if(valStr == "0") processedVal = "0." + new string('0', sf);
            else processedVal = valStr + "." + new string('0', sf - valStr.Length);
        }
    }
    return processedVal;
}