string FormatToSignificantFigures(float val, int figures) {
    int shift = (int)Math.Ceiling(Math.Log10(val)) - figures;
    if(Math.Log10(val) == Math.Truncate(Math.Log10(val))) {
        shift++;
    }

    if(shift == 0) {
        return ((int)val).ToString();
    }

    int shiftedVal = (int)Math.Round(val / Math.Pow(10, shift));

    if(shift > 0) {
        return (shiftedVal * (int)Math.Pow(10, shift)).ToString();
    }

    string formattedVal;
    if(val < 1) {
        formattedVal = "0.";
        for(float tempVal = 10f * val; tempVal < 1; tempVal *= 10f) {
            formattedVal += "0";
        }
        return formattedVal + shiftedVal.ToString();
    }

    return shiftedVal.ToString().Insert(shiftedVal.ToString().Length + shift, ".");
}
