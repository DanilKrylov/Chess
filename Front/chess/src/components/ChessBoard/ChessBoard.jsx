import React, { useState, useEffect, useContext } from 'react';
import Cage from '../UI/Cages/Cage/Cage';
import classes from './ChessBoard.module.css'
import Piece from '../Piece/Piece';
import { observer } from 'mobx-react';
import { BLACK } from '../../utils/colors';
import { Context } from '../..';
import PieceProposingChooser from '../PieceProposingChooser/PieceProposingChooser';

const ChessBoard = observer(({ cageWidth, tryMove, currentGame }) => {
  const [targetFigure, setTargetFigure] = useState(undefined)
  const [position, setPosition] = useState({});
  const {proposingChooserInfo} = useContext(Context)

  useEffect(() => {
    const handleResize = () => setPosition({
      posY: document.getElementsByClassName(classes.chessBoard)[0].getBoundingClientRect().top,
      posX: document.getElementsByClassName(classes.chessBoard)[0].getBoundingClientRect().left
    });

    window.addEventListener('resize', handleResize);
    handleResize()
    return () => window.removeEventListener('resize', handleResize);
  }, [])

  async function mouseMove(event) {
    if (targetFigure) {
      if (event.pageX - 5 < position.posX || event.pageX + 5 > position.posX + cageWidth * 8 ||
        event.pageY - 5 < position.posY || event.pageY + 5 > position.posY + cageWidth * 8) {
        currentGame.setViewPosAsValidPos(targetFigure.pieceIdentifier)
        targetFigure.unhandleClick()
        setTargetFigure(null)
        return;
      }

      if (currentGame.playerRole === BLACK) {
        currentGame.changeViewPosition(targetFigure.pieceIdentifier, {
          posX: 8.5 - (event.pageX - position.posX) / cageWidth,
          posY: (event.pageY - position.posY) / cageWidth + 0.5
        })
      }
      else {
        currentGame.changeViewPosition(targetFigure.pieceIdentifier, {
          posX: (event.pageX - position.posX) / cageWidth + 0.5,
          posY: 8.5 - (event.pageY - position.posY) / cageWidth
        })
      }
    }
  }

  function renderPiece(pieceInfo) {
    return <Piece
      key={pieceInfo.pieceIdentifier}
      pieceIdentifier={pieceInfo.pieceIdentifier}
      setTargetFigure={setTargetFigure}
      tryMove={tryMove}
    />;
  }

  const squares = [];
  for (let i = 0; i < 64; i++) {
    squares.push(<Cage key={i} number={i} />);
  }

  return (
    <div className={classes.chessBoard}
      onMouseMove={mouseMove}
    >
      {squares}
      {currentGame.pieces.map(c => renderPiece(c))}
      {console.log(proposingChooserInfo.isInPieceMenu)}
      {proposingChooserInfo.isInPieceMenu && <PieceProposingChooser boardPosition={position} cageWidth={cageWidth}></PieceProposingChooser>}
    </div>
  );
});

export default ChessBoard;