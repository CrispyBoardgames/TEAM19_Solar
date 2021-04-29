

# Sorting Algorithm for Current Reading
# Function receives a list of values and returns the highest.
# Currents must be read back to back, and not in a round robin fashion.

def SortTopA(Currents):
    topAmp = 2.50

    for amp in Currents:
        # 2.5 is base: 0 Amps. We normalize to 0 to use the properties of absolute values.
        if(abs(amp - 2.50) > abs(topAmp - 2.50)):
            topAmp = amp

    return topAmp

# Call this method after sorting for the top.
# Follows simple linear relationship: 400 mV / 1 Amp
# Since we want the line to be a function of the voltage read (input), we flip and get 2.5 Amp / Volt
# Some simple calculations give us the offset, b, and get Amps = 2.5*Vin - 6.25


def TranslateAmps(Vamp):
    return ((2.5 * Vamp) - 6.25)

# ADC will not see negative values. Thus,  no absolute value necessary. Translation of voltages is not needed.


def SortTopV(Voltages):
    topVolt = 0.0

    for volt in Voltages:
        if(abs(volt) > abs(topVolt)):
            topVolt = abs(volt)

    return topVolt


# Test. Only include functions. Once the value has been stored,  make sure to clear the list: Use listName.clear()


voltValues = [0.0, 2.468, 10.5287, 67.5, 15.9985]
print("Max voltage:")
print(SortTopV(voltValues))

# Current
values = [2.4325, 2.50, 2.6425, 2.11248, 3.684312, 1.2478, 1.0235]
values.append(2.77166)
print("Printing values")
for val in values:
    print(val)

print("Printing top:")
topVamp = SortTopA(values)
print(topVamp)

print("Printing translated top current: ")
print(TranslateAmps(topVamp))
values.clear()

# Once the top voltage and top current
print("Printing cleared list")
for val in values:
    print(val)

print("End")
