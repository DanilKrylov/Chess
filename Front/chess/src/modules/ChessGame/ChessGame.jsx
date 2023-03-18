import { observer } from 'mobx-react';
import React, { useContext, useEffect} from 'react';
import ChessBoard from '../../components/ChessBoard/ChessBoard';
import { joinToGameHub, leftGameHub} from '../../http/gameAPI';
import { Context } from '../..';
import { setCurrentGameInfo, tryDetectCheckMate, tryMovePieceByPlayer } from './chessLogic';
import { useNavigate, useParams } from 'react-router-dom';

const ChessGame = observer(() => {
    const {currentGame, userInfo} = useContext(Context)
    const {gameId} = useParams()
    const navigate =  useNavigate()

    useEffect(() => {
        joinToGameHub(gameInfoSetter, finishGame, gameId, onGameIsNotDefined)
        return onComponentDestruct
    }, [])

    async function onComponentDestruct(){
        await leftGameHub()
        currentGame.clear()
    }

    function onGameIsNotDefined(){
        navigate("/gameInfo/" + gameId)
    }

    function gameInfoSetter(game){
        const userEmail = userInfo.user.email
        setCurrentGameInfo(currentGame, game, userEmail)
        if(!currentGame.isEnded)
            tryDetectCheckMate(currentGame.pieces, currentGame.moveTurn, gameId, currentGame.playerRole)
    }

    function finishGame() {
        navigate("/gameInfo/" + gameId)
    }

    async function tryMove(from, to){
        return await tryMovePieceByPlayer(from, to, currentGame, gameId)
    }

    return (
        <ChessBoard cageWidth={50} tryMove = {tryMove} currentGame = {currentGame}></ChessBoard>
    );
});

export default ChessGame;