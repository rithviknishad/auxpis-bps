%{
Generating sq. wave, by fourier series expansion

EEE2001 NETWORK THEORY - Digital Assignment 1
19BEE1050, RITHVIK NISHAD
----------------------------------------------------
%}

clc
clear all

% Get square wave parameters:
A       = input('Square Wave Amplitude (V)       : ');
T       = input('Enter Time Period (s)           : ');
y       = input('Enter DC offset (V)             : ');

% Get compute parameters: 
cycles  = input('No. of cycles to plot           : ');
n_max   = input('Enter number of terms to compute: ');

w = 2 * pi / T;
t = 0 : .01 : ( T * cycles );

% perform fourier series expansion
for n = 0 : n_max
    y = y + ( sin( (2*n+1) * w * t ) / (2*n+1) );
end

% plot the equivalent
figure
plot(t, y)
title('Square Wave')
xlabel('time (seconds)')
ylabel('Voltage (V)')
