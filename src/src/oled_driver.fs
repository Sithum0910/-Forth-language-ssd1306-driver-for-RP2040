\ SSD1306 OLED Driver for RP2040
\ Clean Version for Production

$3C constant OLED_ADDR
$00 constant OLED_CMD
$40 constant OLED_DATA

: oled-start ( -- )
  i2c-start OLED_ADDR i2c-addr! ;

: oled-cmd! ( c -- )
  oled-start
  OLED_CMD i2c-write
  i2c-write
  i2c-stop ;

: oled-data! ( c -- )
  oled-start
  OLED_DATA i2c-write
  i2c-write
  i2c-stop ;

: oled-init ( -- )
  $AE oled-cmd!
  $D5 oled-cmd! $80 oled-cmd!
  $A8 oled-cmd! $3F oled-cmd!
  $D3 oled-cmd! $00 oled-cmd!
  $40 oled-cmd!
  $8D oled-cmd! $14 oled-cmd!
  $20 oled-cmd! $02 oled-cmd!
  $A1 oled-cmd!
  $C8 oled-cmd!
  $AF oled-cmd! ;

: oled-clear ( -- )
  8 0 do
    $B0 I + oled-cmd!
    $00 oled-cmd!
    $10 oled-cmd!
    128 0 do 0 oled-data! loop
  loop ;

create FONT_H  $7F , $08 , $08 , $08 , $7F ,
create FONT_I  $41 , $41 , $7F , $41 , $41 ,

: draw-char ( addr -- )
  5 0 do
    dup I cells + @ oled-data!
  loop drop ;

: say-hi ( -- )
  oled-init
  oled-clear
  $B0 oled-cmd!
  $00 oled-cmd!
  FONT_H draw-char
  0 oled-data!
  FONT_I draw-char ;
