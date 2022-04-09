import { AisModal, AisGrid } from "@ais-gorod/react-ui";
import { useEffect, useState } from "react";
import { useHistory, useParams } from 'react-router-dom';
import { WorkersWagesApiClient, ManufactoryDetailsResponse } from '../../services/WorkersWagesApiClient';
import PhotoNeutral from './profile-picture-neutral.jpg';

export const ManufactoriesDetailsModal = () => {
    const history = useHistory();
    const { id } = useParams() as {
        id: string;
    };

    const [manufacoryInfo, setManufacoryInfo] = useState<ManufactoryDetailsResponse>();
    useEffect(() => {
        const apiClient = new WorkersWagesApiClient('/extapi');
        apiClient.manufactoriesDetails(+id).then((r) => setManufacoryInfo(r));
    }, [setManufacoryInfo]);

    if (!manufacoryInfo) return null;

    return (
        <AisModal show={true} onHide={() => history.push('/manufactories')} title="Подробности цеха">
            <AisGrid.Row>
                <AisGrid.Col className="text-center">
                    <div>
                        {manufacoryInfo.headPhotoUrl ? (
                            <img src={manufacoryInfo.headPhotoUrl} width={250} height={250} />
                        ) : (
                            <img src={PhotoNeutral} width={250} height={250} />
                        )}
                    </div>
                    <strong>{manufacoryInfo.headFIO}</strong>
                </AisGrid.Col>
                <AisGrid.Col>
                    <div>
                        <strong>Название: </strong> {manufacoryInfo.name}
                    </div>
                    <div>
                        <strong>Номер: </strong> {manufacoryInfo.number}
                    </div>
                </AisGrid.Col>
            </AisGrid.Row>
        </AisModal>
    );
};

ManufactoriesDetailsModal.displayName = 'ManufactoriesDetailsModal';
