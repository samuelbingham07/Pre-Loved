# class work todo

- don't edit while game is playing (changes get lost). ctrl+s a lot
- optional: edit > preferences > colors > playmode tint → red so i notice

## fix UI
- canvas > canvas scaler: scale with screen size, 1920x1080, match 0.5
- fadeimage: rect transform square icon, alt+click bottom right (stretch all), left/top/right/bottom = 0. untick raycast target
- order under canvas: hoverpanel, inspectpanel, fadeimage LAST
- picture: alt+click stretch all. left 100 right 100 top 50 bottom 250. leave source image empty
- text (tmp) in inspectpanel: rename description. alt+click bottom row far right. left/right 150, pos y 40, height 180. delete "new text", size 36, centered, white
- close button: alt+click top right. pos -40, -40. size 160x60. text = close
- close button on click: + → drag inspectviewer → InspectViewer > Close
- inspectpanel colour: black, A ~230

## finish converse tee
- ConverseTee asset: display name, mirror image (me wearing it), try on text (optional)
- photo won't drag in → texture type sprite (2d and ui), max size 4096, apply
- photo sideways → rotation z 90 / -90, or rotate in photos app
- to see mirror view: untick closet, tick mirror
- FrontHit + Tag: label, close up, description. line up green box (W to move, edit collider to resize)
- more details: ctrl+d an existing one
- Mirror (mirror spot) in garment1group: green box over the mirror
- tick closet back on, untick mirror
- arrowleft: tick needs garment, or just delete it
- test: hover name → click → mirror → details → close → click mirror → arrow back

## rack frames
- import frame photos, select all → sprite, 4096, apply
- right click closet > create empty > RackController, add rack controller script
  - closet renderer = closetpicture
  - frames = photos in order (0 = all six on the right)
  - frame garments = same count, garment in the pickzone spot each frame, empty if none
  - pick zone = pickzone
- converse tee only clickable in whichever frame it's in under frame garments
- rack arrows: ctrl+d arrowleft → RackArrowLeft, remove view arrow, add rack arrow, rack = rackcontroller, direction -1
- ctrl+d that → RackArrowRight, direction 1, scale x -1 to flip
- (if arrowleft is deleted use mirror's arrowright and drag the copy into closet)
- test: arrows go through frames, stop at the ends

## more garments
- create > scriptable objects > garmentdata. name, mirror image, try on text
- put it in rackcontroller frame garments
- mirror on: ctrl+d garment1group → garment2group. swap the photo sprite, redo details + mirror spot. untick the group
- mirror > mirror view: add garment to garments, group to hanging garments (same order!)
- shelf garments: ctrl+d pickzone → shelfzone1, put over shelf item, set garment. NOT in rackcontroller. still needs a mirror group

## end
- ctrl+s
- vs code source control → message → commit
- write down what's done + any red console errors for claude

## if broken
- changes gone = was in play mode
- nothing responds = interactor click action needs Left Button [Mouse] binding
- hover nothing = no box collider 2d, or no garment in that frame
- small black square = fadeimage not stretched
- tiny close-up = picture not stretched
- close does nothing = on click not set / raycast target on fadeimage
- wrong garment in mirror = mirror view lists out of order
- white/pink photo = not a sprite / slot empty
- tinted photo = sprite renderer colour → FFFFFF
- error about rackcontroller = closet renderer or pick zone empty
- error about inspectviewer = its slots empty
- missing field in inspector = click unity, ctrl+r
- stuck 10+ min → skip it, write it down
